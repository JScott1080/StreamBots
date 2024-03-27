// JavaScript source code
import fs from 'fs';
import path from 'path';
import { fileURLToPath, URL }  from 'url';

import readline from 'readline';
import tmi from 'tmi.js';
import axios from 'axios';
import { parseAdminCmd, parseGameCmd } from './ChatParser.js';
import { getTwitchAuth, GetModerators } from './API/Overlord.js';
import { gameCommands } from './ChatCommands/GameCommander.js';

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
                parseAdminCmd(command)
            }
            break;

        case '!':

            if (voting) {
                vote(command);
                break;
            }

            if (democracy)
                liberTea(command);
            else
                parseGameCmd(msg);
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

    for (const ids in mods) {
        if (ids.user_name == `#` + User)
            return true;
    }
    return false;
}

function votingStart() {
    //pause commands
}

function votingEnd() {

}

async function vote(message) {
    //to;do determing how the game will be played, via liberTea() or anarchy



}

async function liberTea(message) {
    //to;do create a system to take the last x commands and then parse the most common one.
}