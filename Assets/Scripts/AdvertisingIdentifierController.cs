using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdvertisingIdentifierController
{
    [DllImport("__Internal")]
    private static extern bool IsNeedToRequestIDFAInternal();
    
    [DllImport("__Internal")]
    private static extern bool GetIDFAInternal();

    public static bool IsNeedToRequestIDFA()
    {
        try
        {
            return GetIDFAInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("IsNeedToRequestIDFA error: " + exception.Message);
        }

        return false;
    }
    
    public static bool GetIDFA()
    {
        try
        {
            return GetIDFAInternal();
        }
        catch (Exception exception)
        {
            Debug.LogError("GetIDFA error: " + exception.Message);
        }

        return false;
    }
}
