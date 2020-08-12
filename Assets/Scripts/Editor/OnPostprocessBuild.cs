#if UNITY_IOS

using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class OnPostprocessBuild
{
    private const string USER_TRACK_USAGE_DESCRIPTION = "App would like to access IDFA for tracking purpose";
    
    [PostProcessBuild]
    public static void OnPostprocessBuildHandler(BuildTarget buildTarget, string path)
    {
        var projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
   
        var proj = new PBXProject ();
        proj.ReadFromString (File.ReadAllText (projPath));
   
        var target = proj.TargetGuidByName ("Unity-iPhone");

        proj.AddFrameworkToProject(target, "AdSupport.framework", true);
        proj.AddFrameworkToProject(target, "AppTrackingTransparency.framework", true);
        
        var plistPath = path + "/Info.plist";
        var plist = new PlistDocument();
        plist.ReadFromString(File.ReadAllText(plistPath));

        var rootDict = plist.root;
        
        rootDict.SetString("NSUserTrackingUsageDescription", USER_TRACK_USAGE_DESCRIPTION);
   
        File.WriteAllText(plistPath, plist.WriteToString());
        File.WriteAllText (projPath, proj.WriteToString ());
    }
}

#endif
