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
        case 'z' || 'v' || 'x' || 'f' || 'r' || 'u' || 'n' || 'i' || 'k' || 'b' || 'l' || 'j' || 'm' || 'p' || 'h' || 'y' || 'g':
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
            robot.keyTap('shift');
            break;
        case 'pma' || 'et':
            robot.keyTap('alt');
            break;
        case 'tgh':
            robot.keyTap('c', 'shift');
            break;
        case 'th':
            robot.keyTap('c');
            break;
        case 'jump':
            robot.keyTap('z');
            break;
        case 'shove':
            robot.keyTap('v');
            break;
        case 'throw':
            robot.keyTap('x');
            break;
        case 'tc':
            robot.keyTap('shift');
            break;
        case 'tws':
            robot.keyTap('f');
            break;
        case 'tdw':
            robot.keyTap('r');
            break;
        case 'suw':
            robot.keyTap('u');
            break;
        case 'end' || 'cet' || 'skip' || 'ta':
            robot.keyTap('space');
            break;
        case 'tbm' || 'run':
            robot.keyTap('space', 'shift');
            break;
        case 'sr':
            robot.keyTap('y');
            break;
        case 'tgm':
            robot.keyTap('g');
            break;
        case 'cs':
            robot.keyTap('n');
            break;
        case 'inv':
            robot.keyTap('i');
            break;
        case 'pv':
            robot.keyTap(';');
            break;
        case 'sb':
            robot.keyTap('k');
            break;
        case 'ip':
            robot.keyTap('b');
            break;
        case 'reac':
            robot.keyTap('l');
            break;
        case 'journal':
            robot.keyTap('j');
            break;
        case 'map':
            robot.keyTap('m');
            break;
        case 'ins':
            robot.keyTap('p');
            break;
        case 'alch':
            robot.keyTap('h');
            break;
        case 'quicksave':
            robot.keyTap('f5');
            break;
        case 'quickload':
            robot.keyTap('f8');
            break;
        case 'rmb' || 'cm' || 'ca':
            robot.mouseClick('right');
            break;
        case 'cw':
            robot.keyTap('"');
            break;
        case 'ept':
            robot.keyTap('t');
            break;
        case 'cp1':
            robot.keyTap('1', 'alt');
            break;
        case 'cp2':
            robot.keyTap('2', 'alt');
            break;
        case 'cp3':
            robot.keyTap('3', 'alt');
            break;
        case 'cp4':
            robot.keyTap('4', 'alt');
            break;
        case 'snc':
            robot.keyTap(']');
            break;
        case 'spc':
            robot.keyTap('[');
            break;
        case 'ui':
            robot.keyTap('f10');
            break;
        default:
            break;
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


