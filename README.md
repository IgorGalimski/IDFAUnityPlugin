Use Xcode 12+

1. Before build - Go to Scripts/Editor/OnPostprocessBuild and replace USER_TRACK_USAGE_DESCRIPTION to your description
2. To request IDFA
2.1 Check if iOS 14+ - by calling AdvertisingIdentifierController.IsNeedToRequestIDFA()

2.1.1 If status ATTrackingManagerAuthorizationStatusAuthorized (an user gave access) - call AdvertisingIdentifierController.GetIDFA(), it will return IDFA

2.1.2 If status ATTrackingManagerAuthorizationStatusDenied (an user restricted usage) - nothing to do

2.1.3 If status ATTrackingManagerAuthorizationStatusNotDetermined (the user wasn't asked) - call AdvertisingIdentifierController.RequestAuthorization() and subscribe to status AdvertisingIdentifierController.ATTrackingManagerAuthorizationStatusEvent.IDFA(check status 2.1.1 and 2.1.2) 

2.1.4 Status ATTrackingManagerAuthorizationStatusRestricted looks like bug https://developer.apple.com/forums/thread/656947
