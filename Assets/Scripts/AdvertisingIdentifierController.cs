using System;
using System.Runtime.InteropServices;
using AOT;
using DefaultNamespace;
using UnityEngine;

public class AdvertisingIdentifierController
{
    [DllImport("__Internal")]
    private static extern bool IsNeedToRequestIDFAInternal();
    
    [DllImport("__Internal")]
    private static extern string GetIDFAInternal();
    
    [DllImport("__Internal")]
    private static extern ATTrackingManagerAuthorizationStatus GetAuthorizationStatusInternal();
    
    [DllImport("__Internal")]
    private static extern void RequestAuthorizationInternal(AuthorizationStatusCallbackDelegate callback);
    
    private delegate void AuthorizationStatusCallbackDelegate(ATTrackingManagerAuthorizationStatus status);

    private static event Action<ATTrackingManagerAuthorizationStatus> ATTrackingManagerAuthorizationStatusEvent =
        status => { };

    public static bool IsNeedToRequestIDFA()
    {
        try
        {
            return IsNeedToRequestIDFAInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("IsNeedToRequestIDFA error: " + exception.Message);
        }

        return false;
    }
    
    public static string GetIDFA()
    {
        try
        {
            return GetIDFAInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("GetIDFA error: " + exception.Message);
        }

        return string.Empty;
    }
    
    public static ATTrackingManagerAuthorizationStatus GetAuthorizationStatus()
    {
        try
        {
            return GetAuthorizationStatusInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("GetAuthorizationStatusInternal error: " + exception.Message);
        }

        return ATTrackingManagerAuthorizationStatus.ATTrackingManagerAuthorizationStatusDenied;
    }
    
    public static void RequestAuthorization(Action<ATTrackingManagerAuthorizationStatus> callback)
    {
        try
        {
            ATTrackingManagerAuthorizationStatusEvent += callback;
            
            RequestAuthorizationInternal(RequestAuthorizationCallback);
        }
        catch (Exception exception)
        {
            Debug.LogError("RequestAuthorizationInternal error: " + exception.Message);
        }
        finally
        {
            ATTrackingManagerAuthorizationStatusEvent -= callback;
        }
    }

    [MonoPInvokeCallback(typeof(AuthorizationStatusCallbackDelegate))]
    private static void RequestAuthorizationCallback(ATTrackingManagerAuthorizationStatus status)
    {
        ATTrackingManagerAuthorizationStatusEvent(status);
    }
}
