export default {};
import robot from 'robotjs';

export const commandMarkers = [
     '!', "-", "_"
];

export async function gameCommands(key) {

    switch (key) {
        case 'w' || 'a' || 's' || 'd':
            robot.keyToggle(key, 'down');
            setTimeout(function () { robot.keyToggle(key, 'up'); }, _duration);;
            break;
        case 'mup':
            robot.moveMouseSmooth(mouse.x, mouse.y - _distance);
            break;
        case 'mle':
            robot.moveMouseSmooth(mouse.x - _distance, mouse.y);
            break
        case 'mwd':
            robot.moveMouseSmooth(mouse.x, mouse.y + _distance);
            break;
        case 'mri':
            robot.moveMouseSmooth(mouse.x + _distance, mouse.y);
            break;
        case 'z' || 'v' || 'x' || 'f' || 'r' || 'u' || 'n' || 'i' || 'k' || 'b' || 'l' || 'j' || 'm' || 'p' || 'h':
            robot.keyTap(key);
            break;
        case 'ttc':
            robot.keyTap('o');
            break;
        case 'crl':
            robot.keyToggle('q', 'down');
            setTimeout(function () { robot.keyToggle('q', 'up'); }, 250);
            break;
        case 'crr':
            robot.keyToggle('e', 'down');
            setTimeout(function () { robot.keyToggle('e', 'up'); }, 250);
            break;
        case 'czi':
            robot.keyToggle('pageup', 'down');
            setTimeout(function () { robot.keyToggle('pageup', 'up'); }, 100);
            break;
        case 'czo':
            robot.keyToggle('pagedown', 'down');
            setTimeout(function () { robot.keyToggle('pagedown', 'up'); }, 100);
            break;
        case 'ccc':
            robot.keyTap('home');
            break;
        case 'lmb':
            robot.MouseClick('left');
            break;
        case 'hlc':
            robot.keyTap('1', 'shift');
            break;
        case 'sil':
            robot.keyTap('2', 'shift');
            break;
        case 'ssc':
        case 'pmc':
        case 'tgh':
        case 'th':
        case 'tc':
        case 'end':
        case 'tbm':
        case 'sr':
        case 'run':
        case 'pv':
        case 'quicksave':
            robot.keyTap('f5');
            break;
        case 'quickload':
            robot.keyTap('f8');
            break;
        case 'rmb':
        case 'ca':
        case 'cw':
        case 'et':
        case 'ept':
        case 'skip':
        case 'ta':
        case 'cp1':
        case 'cp2':
        case 'cp3':
        case 'cp4':
        case 'snc':
        case 'spc':
        case 'ui':
    };

}

function moveCharacter(key, _duration = 1000) {
    robot.keyToggle(key, 'down');
    setTimeout(function () { robot.keyToggle(key, 'up'); }, _duration);
}

function gameAction(key) {
    robot.keyTap(key);
}

function moveMouse(direction, _distance = 100) {
    var mouse = robot.getMousePos();
    switch (direction) {
        case 'right':
            robot.moveMouseSmooth(mouse.x + _distance, mouse.y);
            break;
        case 'left':
            robot.moveMouseSmooth(mouse.x - _distance, mouse.y);
            break;
        case 'up':
            robot.moveMouseSmooth(mouse.x, mouse.y - _distance);
            break;
        case 'down':
            robot.moveMouseSmooth(mouse.x, mouse.y + _distance);
            break;
        default:
            break;
    }
}

gameCommands(process.stdin);

process.stdin.on('keypress', (ch, key) => {
    if (key && key.name === 'escape') {
        process.stdin.pause();
    }
});


