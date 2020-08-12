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
    char* GetIDFA()
    {
        NSUUID *IDFA = [[ASIdentifierManager sharedManager] advertisingIdentifier];
        NSString *idfaString = [IDFA UUIDString];
        
        return cStringCopy([idfaString UTF8String]);
    }

    ATTrackingManagerAuthorizationStatus GetAuthorizationStatus()
    {
        return [ATTrackingManager trackingAuthorizationStatus];
    }
}

