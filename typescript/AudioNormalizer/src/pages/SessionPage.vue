<template>
    <q-page class="row items-center justify-evenly">
        <q-btn color="primary" :loading="isConnecting" v-if="!isConnected" @click="joinSession"> Join Session </q-btn>
        <ParticipantsList v-if="isConnected" />
    </q-page>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useAppStore } from "src/stores/app-store";
import { WebRtcClientState } from "src/libs/webrtc/webrtc-client";
import ParticipantsList from "src/components/ParticipantsList.vue";

const webRtcClient = useAppStore().webRtcClient;

export default defineComponent({
    name: "SessionPage",
    setup() {
        return {};
    },
    components: {
        ParticipantsList,
    },
    computed: {
        isConnected() {
            return webRtcClient.state === WebRtcClientState.Connected;
        },
        isConnecting() {
            return webRtcClient.state === WebRtcClientState.Connecting;
        },
    },
    methods: {
        async joinSession() {
            await webRtcClient.connect();
        },
        onAudioLevelChanged(participantId: number, lastAudioLevel: number) {
            // TODO: Normalize audio levels
            console.log(`Audio level is ${lastAudioLevel} for user ${participantId}`);
        },
    },
    mounted() {
        webRtcClient.onAudioLevelChanged = this.onAudioLevelChanged;
    },
});
</script>
