

export async function parseAdminCmd(command) {

    let parcedCommand = command.substring(1);
    let spaceIndex = parcedCommand.indexOf(" ");

    if (spaceIndex > 0)
        parcedCommand = parcedCommand.substring(0, spaceIndex);

    console.log(parcedCommand);

    return parcedCommand;

} 

export async function parseGameCmd(command) {

    let parcedCommand = command.substring(1);
    let spaceIndex = parcedCommand.indexOf(" ");

    if(spaceIndex > 0)
        parcedCommand = parcedCommand.substring(0, spaceIndex);

    console.log(parcedCommand);

    return parcedCommand;
}