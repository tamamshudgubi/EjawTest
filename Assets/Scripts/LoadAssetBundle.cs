using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    private string _bundleUrl = "";
    private int _version = 0;
    private DataSaver _data = new DataSaver();

    public List<GameObject> GeometryObjects { get; private set; }

    private void Start()
    {
        _data.PrimitivesNames = _data.GetPrimitivesNames();
        StartCoroutine(DownloadAndChacheBundle());
    }

    private IEnumerator DownloadAndChacheBundle()
    {
        while (!Caching.ready)
        {
            yield return null;
        }

        var www = WWW.LoadFromCacheOrDownload(_bundleUrl, _version);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            yield break;
        }

        var assetBundle = www.assetBundle;

        foreach (var geometry in _data.PrimitivesNames)
        {
            var geometryObject = assetBundle.LoadAssetAsync(geometry, typeof(GameObject));
            GeometryObjects.Add(geometryObject.asset as GameObject);
        }
    }
}
