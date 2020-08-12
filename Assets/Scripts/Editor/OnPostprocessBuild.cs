#if UNITY_IOS

using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class OnPostprocessBuild
{
    [PostProcessBuild]
    public static void OnPostprocessBuildHandler( BuildTarget buildTarget, string path )
    {
        var projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
   
        var proj = new PBXProject ();
        proj.ReadFromString (File.ReadAllText (projPath));
   
        var target = proj.TargetGuidByName ("Unity-iPhone");

        proj.AddFrameworkToProject(target, "AdSupport.framework", true);
        proj.AddFrameworkToProject(target, "AppTrackingTransparency.framework", true);
   
        File.WriteAllText (projPath, proj.WriteToString ());
    }
}

#endif
