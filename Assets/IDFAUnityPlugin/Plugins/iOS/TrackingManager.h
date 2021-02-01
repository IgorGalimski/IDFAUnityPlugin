//
//  ATTrackingManager.h
//  Unity-iPhone
//
//  Created by Igor Galimski on 2/1/21.
//

#import <AppTrackingTransparency/AppTrackingTransparency.h>

#ifndef TrackingManager_h
#define TrackingManager_h

API_AVAILABLE(ios(14))
typedef void (*ATTrackingManagerAuthorizationStatusCallback)(ATTrackingManagerAuthorizationStatus status);

@interface TrackingManager : NSObject

+ (TrackingManager *)sharedInstance;

-(bool) IsNeedToRequestIDFA;
-(char*) GetIDFA;
-(ATTrackingManagerAuthorizationStatus*) GetAuthorizationStatus API_AVAILABLE(ios(14));
-(void) RequestAuthorization: (ATTrackingManagerAuthorizationStatusCallback) callback API_AVAILABLE(ios(14));

@end

#endif /* TrackingManager_h */
