using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    private DataSaver _data = new DataSaver();

    public List<GameObject> GeometryObjects = new List<GameObject>();

    private void Start()
    {
        _data.PrimitivesNames = _data.GetPrimitivesNames();
        StartCoroutine(DownloadAndChacheBundle());
    }

    private IEnumerator DownloadAndChacheBundle()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        string filePath = Path.Combine(Path.Combine(path, "primitiveobjects"));

        var request = AssetBundle.LoadFromFileAsync(Path.Combine("file:///", filePath));
        yield return request;

        AssetBundle assetBundle = request.assetBundle;

        foreach (var geometry in _data.PrimitivesNames)
        {
            AssetBundleRequest geometryObject = assetBundle.LoadAssetAsync(geometry, typeof(GameObject));
            GeometryObjects.Add(geometryObject.asset as GameObject);
        }
    }
}
