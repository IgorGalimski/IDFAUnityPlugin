using System;
using System.Runtime.InteropServices;
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
    private static extern void RequestAuthorizationInternal();

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
    
    public static void RequestAuthorization()
    {
        try
        {
            RequestAuthorizationInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("RequestAuthorizationInternal error: " + exception.Message);
        }
    }
}
