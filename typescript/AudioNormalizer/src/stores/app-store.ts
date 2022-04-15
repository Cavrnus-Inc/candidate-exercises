import { defineStore } from "pinia";
import WebRtcClient from "src/libs/webrtc/webrtc-client";
import { reactive } from "vue";

export const useAppStore = defineStore("app", {
    state: () => ({
        webRtcClient: reactive(new WebRtcClient()),
    }),
});
