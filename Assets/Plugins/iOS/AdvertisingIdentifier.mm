//
//  AdvertisingIdentifier.m
//  Test
//
//  Created by Igor Galimski on 8/12/20.
//

#import <AdSupport/ASIdentifierManager.h>
#import <AppTrackingTransparency/AppTrackingTransparency.h>

char* cStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;

    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);

    return res;
}

extern "C"
{
    typedef void (*ATTrackingManagerAuthorizationStatusCallback)(ATTrackingManagerAuthorizationStatus status);

    bool IsNeedToRequestIDFAInternal()
    {
        if(@available(iOS 14, *))
        {
            return true;
        }
        
        return false;
    }

    char* GetIDFAInternal()
    {
        NSUUID *IDFA = [[ASIdentifierManager sharedManager] advertisingIdentifier];
        NSString *idfaString = [IDFA UUIDString];
        
        return cStringCopy([idfaString UTF8String]);
    }

    ATTrackingManagerAuthorizationStatus GetAuthorizationStatusInternal()
    {
        return [ATTrackingManager trackingAuthorizationStatus];
    }

    void RequestAuthorizationInternal(ATTrackingManagerAuthorizationStatusCallback callback)
    {
        if (@available(iOS 14, *))
        {
            [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus status)
            {
                callback(status);
            }];
        }
    }
}

