# Audio Normalizer Exercise


## TASK: Normalize audio levels

Create an instance of the `UserAudioNormalizer` class and add it to the `AudioProcessors` list on the `WebRtcClient`.

Implement the `OnAudioLevelChanged` method to calculate audio level gain values so that all users have audio levels within a range of 40 to 60 (out of 100). 

Set a user's audio level gain by calling `SetUserGain` on the `WebRtcClient`.


## TASK: Display audio report

The second task is retrieve audio level data by calling `GetAudioReport` on the `WebRtcClient` and display a summary of users and their respective audio level gain values. 
