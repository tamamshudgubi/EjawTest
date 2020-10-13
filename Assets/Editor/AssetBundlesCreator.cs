using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundlesCreator
{
    [MenuItem("Assets/Build Assets")]
    private static void BuildAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(Path.Combine(Application.streamingAssetsPath, "AssetBundles"), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
