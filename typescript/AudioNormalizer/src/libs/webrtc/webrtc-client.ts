import { Participant } from "src/components/models";
import Rng from "../rng";
import Task from "../tasks";

export default class WebRtcClient {
    private _simulate = false;
    private _levels = new Map<string, number>([
        ["Leonardo", 50],
        ["Rafael", 70],
        ["Donatelo", 30],
    ]);
    public participants: Participant[] = [];
    public state = WebRtcClientState.Disconnected;
    public onAudioLevelChanged?: (participantId: number, lastAudioLevel: number) => void;

    public async connect(): Promise<void> {
        this.state = WebRtcClientState.Connecting;
        await Task.delay(Rng.next(0, 1000));
        this.state = WebRtcClientState.Connected;
        this.startSimulation();
    }

    public async disconnect(): Promise<void> {
        this.state = WebRtcClientState.Disconnecting;
        await Task.delay(Rng.next(0, 1000));
        this.stopSimulation();
        this.state = WebRtcClientState.Disconnected;
    }

    public setParticipantAudioLevelGain(participantId: number, gain: number) {
        const participant = this.participants[participantId];
        participant.audioLevelGain = gain;
    }

    private async startSimulation() {
        const names = ["Leonardo", "Rafael", "Donatelo"];
        for (const i in names) {
            this.participants.push({
                id: i as unknown as number,
                name: names[i],
                audioLevelGain: 0,
                avatar: `images/${names[i].toLocaleLowerCase()}.png`,
                lastAudioLevel: 0,
            });
        }

        this._simulate = true;

        while (this._simulate) {
            await Task.delay(Rng.next(0, 666));
            const participant = this.participants[Rng.next(0, this._levels.size)];
            const isTalking = Rng.next(0, 100) > 25;
            const baseLevel = this._levels.get(participant.name) as number;
            const flux = 8;
            const level = isTalking ? baseLevel + participant.audioLevelGain + Rng.next(-flux, flux) : 0;
            participant.lastAudioLevel = level;
            if (this.onAudioLevelChanged) this.onAudioLevelChanged(participant.id, level);
        }
    }

    private stopSimulation() {
        this._simulate = false;
    }
}

export enum WebRtcClientState {
    Connected,
    Connecting,
    Disconnected,
    Disconnecting,
}
