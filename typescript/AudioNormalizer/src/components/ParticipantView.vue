<template>
    <div class="col-auto">
        <q-card class="my-card">
            <q-img :src="avatar">
                <div :class="getColorForAudioLevel(lastAudioLevel)">
                    <b>{{ lastAudioLevel }}</b>
                </div>
                <div class="text-h5 absolute-bottom text-right">{{ name }}</div>
            </q-img>
        </q-card>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    name: "ParticipantView",
    props: {
        avatar: {
            type: String,
            required: true,
        },
        lastAudioLevel: {
            type: Number,
            required: true,
        },
        name: {
            type: String,
            required: true,
        },
    },
    methods: {
        getColorForAudioLevel(audioLevel: number) {
            if (audioLevel === 0) return "text-blue-grey-11";
            if (audioLevel > 60) return "text-red-11";
            if (audioLevel < 40) return "text-yellow-11";
            return "text-light-green-11";
        },
    },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 200px
  max-width: 250px
</style>
