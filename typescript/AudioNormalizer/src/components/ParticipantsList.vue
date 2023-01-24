<template>
    <div class="fit">
        <div class="row justify-center q-ma-md">
            <div class="col-auto">
                <div class="text-h4">Session Participants</div>
            </div>
        </div>
        <div class="row justify-center q-col-gutter-md">
            <ParticipantView v-for="participant in participants" :key="participant.name" v-bind="participant" />
        </div>
    </div>
</template>

<script lang="ts">
import { useAppStore } from "src/stores/app-store";
import { defineComponent } from "vue";
import ParticipantView from "src/components/ParticipantView.vue";

const store = useAppStore();

export default defineComponent({
    name: "ParticipantsList",
    components: { ParticipantView },
    setup() {
        return {
            participants: store.webRtcClient.getParticipants(),
        };
    },
});
</script>
