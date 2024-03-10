let clientId = "lq1tzm68ep4qvipym40apgizf45sr6";
let clientSecret = "22i9hawqpws4s4k3q99via9vtywbr0";

export default {}

export function initTwitchConnections()
{

}

function getTwitchAuth() {
    let url = 'https://id.twitch.tv/oauth2/token?client_id=$lq1tzm68ep4qvipym40apgizf45sr6&client_secret=$22i9hawqpws4s4k3q99via9vtywbr0&grant_type=client_credentials';
    fetch((url), {
        method: "POST",
    })
        .then((res) => res.json())
        .then((data) => handleAuth(data));
}

function handleAuth(data) {
    let { access_token, expires_in, token_type } = data;
    //console.log('${token_type} ${access_token}');
}

getTwitchAuth();

