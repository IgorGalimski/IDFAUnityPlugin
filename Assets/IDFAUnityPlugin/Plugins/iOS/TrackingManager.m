//
//  ATTrackingManager.m
//  Unity-iPhone
//
//  Created by Igor Galimski on 2/1/21.
//

#import <Foundation/Foundation.h>
#import "TrackingManager.h"
#import <AdSupport/ASIdentifierManager.h>
#import <AppTrackingTransparency/AppTrackingTransparency.h>

@implementation TrackingManager

+ (TrackingManager *)sharedInstance
{
    static TrackingManager *instance = nil;
    static dispatch_once_t token;

    dispatch_once(&token, ^{
      instance = [[TrackingManager alloc] init];
    });
    
    return instance;
}

-(bool) IsNeedToRequestIDFA
{
    if(@available(iOS 14, *))
    {
        return true;
    }
    
    return false;
}

-(char*) GetIDFA
{
    NSUUID *IDFA = [[ASIdentifierManager sharedManager] advertisingIdentifier];
    NSString *idfaString = [IDFA UUIDString];
    
    const char* str = [idfaString UTF8String];
    
    if (str == NULL)
    {
        return NULL;
    }
    
    char* res = (char*)malloc(strlen(str) + 1);
    strcpy(res, str);
    
    return res;
}

-(ATTrackingManagerAuthorizationStatus*) GetAuthorizationStatus
{
    return [ATTrackingManager trackingAuthorizationStatus];
}

-(void) RequestAuthorization: (ATTrackingManagerAuthorizationStatusCallback) callback
{
    [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus status)
    {
        dispatch_async(dispatch_get_main_queue(), ^
        {
            callback (status);
        });
    }];
}

@end
