# Audio Normalizer Exercise

## Install the dependencies

```bash
cd typescript\AudioNormalizer
yarn
# or
npm install
```

## Start the app

```bash
yarn quasar dev
```

## TASK : Visualize audio levels

In `src/components/ParticipantView.vue`, the `lastAudioLevel` property is updated as a participant speaks or goes silent. Update the visualization of each participant card to reflect their last audio level and apply a style to show audio's threshold (loud, quiet, normal) 

## TASK: Normalize audio levels

In `src/pages/SessionPage.vue`, use the `onAudioLevelChanged` event handler to calculate audio level gain values so that all users have audio levels within a range of 40 to 60 (out of 100).

Set a user's audio level gain by calling `setParticipantAudioLevelGain` on the `webRtcClient`.
