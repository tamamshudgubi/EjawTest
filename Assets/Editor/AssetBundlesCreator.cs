using UnityEditor;

public class AssetBundlesCreator
{
    [MenuItem("Assets/Build Assets")]
    private static void BuildAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Prefabs", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
