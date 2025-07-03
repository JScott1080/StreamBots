// JavaScript source code
import fs from 'fs';
import path from 'path';
import { fileURLToPath, parse, URL }  from 'url';

import readline from 'readline';
import tmi from 'tmi.js';
import axios from 'axios';
import { parseAdminCmd, parseGameCmd } from './ChatParser.js';
import { getTwitchAuth, GetModerators } from './API/Overlord.js';
import { gameCommands } from './ChatCommands/GameCommander.js';
import { VotingModeManager } from './VotingModeManager.js';

import { escape } from 'querystring';

const config = JSON.parse(fs.readFileSync(path.join(
    path.dirname(fileURLToPath(import.meta.url)),
    'config.json'
)));

const auth_file = path.join(
    path.dirname(fileURLToPath(import.meta.url)),
    'auth.json'
);

let auth_data = {};
let mods = {};

let authorization = '';

let voting = false;
let democracy = false;
let eStop = false;

const modeManager = new VotingModeManager();


const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Define configuration options
const opts = {
    identity: {
        username: config.username,
        password: config.password
    },
    channels: [
        config.channelName
    ]
};

// Create a client with our options
const client = new tmi.client(opts);

// Register our event handlers (defined below)
client.on('message', onMessageHandler);
client.on('connected', onConnectedHandler);

// Connect to Twitch:
client.connect();

// Called every time a message comes in
async function onMessageHandler(target, context, msg, self) {
    if (self) { return; } // Ignore messages from the bot c

    const command = msg.toLowerCase();

    switch (command.charAt(0)) {

        case '~':
            if (isMod(context.username) || context.username == config.channelName) {
                adminCommands(await parseAdminCmd(command));
            }
            break;

        case '!':

            if (!eStop) {

                if (voting) {
                    vote(command);
                    break;
                }

                if (democracy)
                    liberTea(command);
                else
                    gameCommands(await parseGameCmd(command));
                break;
            }
            break;
    }
}



// Called every time the bot connects to Twitch chat
async function onConnectedHandler(addr, port) {
    console.log(`* Connected to ${addr}:${port}`);
}

startBot();

async function startBot() {
    auth_data = await getTwitchAuth(config.client_id, config.client_secret);
    authorization = `Bearer ${auth_data.access_token}`;
    declareArival();
    mods = await GetModerators(authorization, config);
    console.log(mods);

    gameCommands('sil');
}
    

async function declareArival() {

    const endpoint = `https://api.twitch.tv/helix/chat/announcements`;


    let headers = {
        "authorization": config.bot_access_token,
        "Client-Id": config.client_id,
        "Content-Type": 'application/json',
    }

    let msgdata = {
        "broadcaster_id": config.broadcast_id,
        "moderator_id": config.bot_id,
        "message": 'ChatPlays bot is live, remember to read the rules!',
        "color": "purple",
    }



    try {
        await axios.post(endpoint, msgdata, { headers });
        console.log("Twitch announcment sent sucessfuly");
    } catch (error) {
        console.error("Error sending Twitch announcement:", error.response.data);
    }
}

async function isMod(User) {
    for (const id of Object.values(mods)) {
        if (id.user_name == User) return true;
    }
}

function votingStart() {
    stopCommands();
    modeManager.resetVotes();
    voting = true;
    console.log("Voting session started.");
}

function votingEnd() {
    voting = false;
    const winner = modeManager.determineWinner();
    democracy = winner === 'democracy';
    client.say(config.channelName, `Voting complete! New mode: ${winner.toUpperCase()}`);
}

async function vote(message) {
    const mode = message.toLowerCase();

    if (modeManager.castVote(mode)) {
        const { democracy, chaos } = modeManager.getVotes();
        console.log(`${mode} vote logged. Democracy: ${democracy}, Chaos: ${chaos}`);
        client.say(config.channelName, `Vote for ${mode} received!`);
    } else {
        console.log("Invalid vote received:", message);
    }
}

let commandCounts = {};
let batchTimer = null;
const BATCH_DURATION = 5000;

async function liberTea(message) {
    const parsed = await parseGameCmd(message);
    if (!parsed) return;

    commandCounts[parsed] = (commandCounts[parsed] || 0) + 1;

    if (!batchTimer) {
        batchTimer = setTimeout(async () => {
            const sorted = Object.entries(commandCounts).sort((a, b) => b[1] - a[1]);

            if (sorted.length > 0) {
                const [mostPopular, count] = sorted[0];
                console.log('Voted command: ${mostPopular} (${count})');
                await gameCommands(mostPopular);
            }

            commandCounts = {};
            batchTimer = null;
        }, BATCH_DURATION);
    }
}

async function adminCommands(command) {

    switch (command) {

        case 'estop':
            stopCommands();
            break;
        case 'PTTP':
            resumeCommands();
            break;
    }
}

function stopCommands() {
    eStop = true; 
    
}

function resumeCommands() {
    eStop = false;
}