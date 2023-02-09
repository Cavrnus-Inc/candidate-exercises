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

In `src/components/ParticipantView.vue`, the `lastAudioLevel` property is updated as a participant speaks or goes silent. Update the visualization of each participant card to reflect their last audio level value and apply a style to color code the audio's threshold.

Loud means the level is greater than 60

Normal means the level is 40 to 60

Quiet means the level is less than 40

Silent means level is 0 (the user is not speaking)

## TASK: Normalize audio levels

In `src/pages/SessionPage.vue`, use the `onAudioLevelChanged` event handler to calculate audio level gain values so that all users have audio levels within a nortmal range of 40 to 60 (out of 100).

Set a user's audio level gain by calling `setParticipantAudioLevelGain` on the `webRtcClient`.
