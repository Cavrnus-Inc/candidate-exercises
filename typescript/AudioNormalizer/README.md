# Audio Normalizer Exercise

## Install the dependencies

```bash
yarn
# or
npm install
```

## Start the app

```bash
yarn quasar dev
```

## TASK: Normalize audio levels

In `src/pages/SessionPage.vue`, use the `onAudioLevelChanged` event handler to calculate audio level gain values so that all users have audio levels within a range of 40 to 60 (out of 100).

Set a user's audio level gain by calling `setParticipantAudioLevelGain` on the `webRtcClient`.
