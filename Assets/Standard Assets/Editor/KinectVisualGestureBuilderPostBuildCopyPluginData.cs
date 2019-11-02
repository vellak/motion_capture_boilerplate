using UnityEditor;
using UnityEditor.Callbacks;

public static class KinectVisualGestureBuilderPostBuildCopyPluginData
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        KinectCopyPluginDataHelper.CopyPluginData(target, path, "vgbtechs");
    }
}