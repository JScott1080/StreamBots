export default {}

export function initTwitchConnections()
{

}

export async function getTwitchAuth(client_id, client_secret) {

    let resp = await fetch(
        `https://id.twitch.tv/oauth2/token?client_id=${client_id}&client_secret=${client_secret}&grant_type=client_credentials`,
        {
            method: "POST",
            "headers": {
                "Accept": "application/json"
            }
        })

    if (resp.status != 200) {
        console.error('An Error occured', await resp.text());
        //process.exit();
    }

    return await resp.json();  

}

export async function getBoradcastingId() {
    let url = "https://api.twitch.tv/helix/users?login=primalchatplays";

    let headers = {
        Authorization: authorization,
        'Client-ID': config.client_id
    };

    let resp = await fetch(url, {
        headers,
    })

    broadcast_data = await resp.json();

    broadcast_data = broadcast_data.data;

    return `${broadcast_data[0]["id"]}`;
}


