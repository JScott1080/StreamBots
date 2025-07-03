// VotingModeManager.js
export class VotingModeManager {
    constructor() {
        this.modes = {
            democracy: 0,
            chaos: 0
        };
        this.activeMode = null;
    }

    castVote(mode) {
        if (this.modes[mode] !== undefined) {
            this.modes[mode]++;
            return true;
        }
        return false;
    }

    getVotes() {
        return { ...this.modes };
    }

    determineWinner() {
        this.activeMode = (this.modes.democracy >= this.modes.chaos) ? 'democracy' : 'chaos';
        return this.activeMode;
    }

    resetVotes() {
        for (let key in this.modes) this.modes[key] = 0;
    }

    getActiveMode() {
        return this.activeMode;
    }
}