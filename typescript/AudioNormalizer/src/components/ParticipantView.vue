<template>
    <div class="col-auto">
        <q-card class="my-card">
            <q-img :src="avatar">
                <div :class="getColorForAudioLevel(lastAudioLevel)">
                    <b>?</b>
                </div>
                <div class="text-h5 absolute-bottom text-right">{{ name }}</div>
            </q-img>
        </q-card>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

enum AudioLevelColor {
    Silent = "text-blue-grey-11",
    Loud = "text-red-11",
    Quiet = "text-yellow-11",
    Normal = "text-light-green-11"
}

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
        }
    },
    methods: {
        getColorForAudioLevel(audioLevel: number) {
            return AudioLevelColor.Silent;
        },
    },
});
</script>

<style lang="sass" scoped>
.my-card
  width: 200px
  max-width: 250px
</style>
