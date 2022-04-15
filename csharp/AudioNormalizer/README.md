# Audio Normalizer Exercise


## TASK: Normalize audio levels

Create an instance of the `UserAudioNormalizer` class and add it to the `AudioProcessors` list on the `WebRtcClient`.

Implement the `OnAudioLevelChanged` method to calculate audio level gain values so that all users have audio levels within a range of 40 to 60 (out of 100). 

Set a user's audio level gain by calling `SetUserGain` on the `WebRtcClient`.
