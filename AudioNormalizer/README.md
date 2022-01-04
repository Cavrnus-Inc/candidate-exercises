# Audio Normalizer Exercise


## TASK: Normalize audio levels

The first task is to set user audio gain so that all users have audio levels within a range of 40 to 60. Use data from the `OnAudioLevelChanged` event to calculate a gain value for a given user and call `SetUserGain` on the `WebRtcClient`.

## TASK: Display audio report

The second task is retrieve audio level data by calling `GetAudioReport` on the `WebRtcClient` and display a summary of users and their respective audio level and gain values.

