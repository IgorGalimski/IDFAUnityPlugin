//
//  AdvertisingIdentifier.m
//  IDFAUnityPlugin
//
//  Created by Igor Galimski on 8/12/20.
//

#import "TrackingManager.h"
#import <AdSupport/ASIdentifierManager.h>
#import <AppTrackingTransparency/AppTrackingTransparency.h>

extern bool IsNeedToRequestIDFAInternal()
{
    return [[TrackingManager sharedInstance] IsNeedToRequestIDFA];
}

extern char* GetIDFAInternal()
{
    return [[TrackingManager sharedInstance] GetIDFA];
}

API_AVAILABLE(ios(14))
extern ATTrackingManagerAuthorizationStatus* GetAuthorizationStatusInternal()
{
    return [[TrackingManager sharedInstance] GetAuthorizationStatus];
}

API_AVAILABLE(ios(14))
extern void RequestAuthorizationInternal(ATTrackingManagerAuthorizationStatusCallback callback)
{
    return [[TrackingManager sharedInstance] RequestAuthorization:callback];
}

