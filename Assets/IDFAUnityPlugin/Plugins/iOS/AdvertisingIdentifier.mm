//
//  AdvertisingIdentifier.m
//  IDFAUnityPlugin
//
//  Created by Igor Galimski on 8/12/20.
//

#import "TrackingManager.h"
#import <AdSupport/ASIdentifierManager.h>
#import <AppTrackingTransparency/AppTrackingTransparency.h>

extern "C" bool IsNeedToRequestIDFAInternal()
{
    return [[TrackingManager sharedInstance] IsNeedToRequestIDFA];
}

extern "C" char* GetIDFAInternal()
{
    return [[TrackingManager sharedInstance] GetIDFA];
}

API_AVAILABLE(ios(14))
extern "C" ATTrackingManagerAuthorizationStatus* GetAuthorizationStatusInternal()
{
    return [[TrackingManager sharedInstance] GetAuthorizationStatus];
}

API_AVAILABLE(ios(14))
extern "C" void RequestAuthorizationInternal(ATTrackingManagerAuthorizationStatusCallback callback)
{
    return [[TrackingManager sharedInstance] RequestAuthorization:callback];
}

