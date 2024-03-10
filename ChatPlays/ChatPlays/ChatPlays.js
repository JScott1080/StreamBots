// JavaScript source code
import fs from 'fs';
import path from 'path';
import { fileURLToPath, URL }  from 'url';
import fetch from 'node-fetch';
import readline from 'readline';
import tmi from 'tmi.js';
import keypress from 'keypress';
import robot from 'robotjs';
import overlord from './Overlord.js';

const config = JSON.parse(fs.readFileSync(path.join(path.dirname(fileURLToPath(import.meta.url)),
    'config.json')));

const auth_file = path.join(
    path.dirname(fileURLToPath(import.meta.url)),
    'auth.json'
);

let auth_data = {};


let clientId = "lq1tzm68ep4qvipym40apgizf45sr6";
let clientSecret = "22i9hawqpws4s4k3q99via9vtywbr0";
let accessToken = 'txv229z4k0e9x7fdxhurphs0t1proo'

let broadcast_id = '';
let authorization = '';

let auth_data = {};

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Define configuration options
const opts = {
    identity: {
        username: 'primalchatplays',
        password: 'oauth:kvw8io034awi4o6333dxrlf7k363ir'
    },
    channels: [
        'xzeroprimex'
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
    if (self) { return; } // Ignore messages from the bot

    // Remove whitespace from chat message
    const commandName = msg.trim();

    switch (commandName.charAt(0)) {
        case '!':

            if (commandName == '!quicksave') {
                simulateKeyPress('f5');
                console.log(`Quick saving game at: ${new Date().toLocaleDateString()}`);
            } else if (commandName == '!quickload') {
                simulateKeyPress('f8');
                console.log(`Quick loading game at: ${new Date().toLocaleDateString()}`);
            }

            break;

        case '~':

            switch (commandName) {
                case '~w':
                    moveCharacter('w');
                    break;
                case '~a':
                    moveCharacter('a');
                    break;
                case '~s':
                    moveCharacter('s');
                    break;
                case '~d':
                    moveCharacter('d');
                    break;
                case '~mouseup':
                    moveMouse('up')
                    break;
                case '~mouseleft':
                    moveMouse('left')
                    break;
                case '~mousedown':
                    moveMouse('down')
                    break;
                case '~mouseright':
                    moveMouse('right')
                    break;

                default:
                    break;
            }
            break;

        //default error catching
        default:

            break;
    }
}

// Called every time the bot connects to Twitch chat
async function onConnectedHandler(addr, port) {
    console.log(`* Connected to ${addr}:${port}`);

    //get authorization data
    await getTwitchAuth();
    
     //get broadcasting data
    await getBoradcastingId();
  


    declareArival();

}

    

function moveCharacter(key, _duration = 1000) {
    robot.keyToggle(key, 'down');
    setTimeout(function () { robot.keyToggle(key, 'up'); }, _duration);
}

function moveMouse(direction, _distance = 100){
    var mouse = robot.getMousePos();
    switch (direction) {
        case 'right':
            robot.moveMouseSmooth(mouse.x+_distance, mouse.y);
            break;
        case 'left':
            robot.moveMouseSmooth(mouse.x-_distance, mouse.y);
            break;
        case 'up':
            robot.moveMouseSmooth(mouse.x, mouse.y-_distance);
            break;
        case 'down':
            robot.moveMouseSmooth(mouse.x, mouse.y+_distance);
            break;
        default:
            break;
    }
}


function simulateKeyPress(key) {
    // Use robot to simulate key presses
    robot.keyTap(key);
    console.log(`Simulating key : ${key}`);
}

keypress(process.stdin);

process.stdin.on('keypress', (ch, key) => {
    if (key && key.name === 'escape') {
        process.stdin.pause();
    }
});


async function getTwitchAuth() {

    rl.question('Code> ', async (code) => {
        let resp = await fetch(
            "https://id.twitch.tv/oauth2/token",
            {
                method: "POST",
                "headers": {
                    "Accept": "application/json"
                },
                "body": new URLSearchParams([
                    ["client_id", config.client_id],
                    ["client_secret", config.client_secret],
                    ["code", code],
                    ["grant_type", "authorization_code"],
                    ["redirect_uri", config.redirect_uri]
                ])
            }
        );

        if (resp.status != 200) {
            console.error('An Error occured', await resp.text());
            //process.exit();
        }

        console.log('OAuth', resp.status, await resp.json());


        auth_data = await resp.json();
        auth_data = JSON.parse(auth_data);

        authorization = `Bearer ${auth_data.access_token}`;

        return;
    });
}

async function getBoradcastingId() {
    let url = "https://api.twitch.tv/helix/users?login=xzeroprimex";

    let headers = {
        Authorization: authorization,
        'Client-ID': clientId
    };

    let resp = await fetch(url, {
        headers,
    })
    console.log('user', resp.status, await resp.json());
    handleBraoadcastId(resp);
}

async function handleAuth(data) {
    let { access_token, expires_in, token_type } = data;
    //token_type first letter must be uppercase    
    token_type =
        token_type.substring(0, 1).toUpperCase() +
        token_type.substring(1, token_type.length);
    authorization = `${token_type} ${access_token}`;

    console.log(`${authorization}`);
}

function handleBraoadcastId(data) {
    let { id, login, display_name, type, broadcaster_type, description, profile_image_url, offline_image_url, view_count, email, created_at } = data;
    broadcast_id = id;
    console.log(`${display_name}`);
}

async function declareArival() {
    const endpoint = `https://api.twitch.tv/helix/chat/announcments?broadcaster_id=${broadcast_id}&moderator_i=${broadcast_id}`;

    let headers = {
        authorization,
        "Client-Id": clientId,
        "Content-Type": 'application/json',
    }

    let data = {
        "Message": 'ChatPlays bot is live, remember to read the rules!',
        "Color": "purple",
    }

    fetch(endpoint, {
        headers, data,
    })
        .then((res) => res.json())
        .then((data) => verifyMessage(data));


}

function verifyMessage(data) {
    console.log(`Message sent`);
}