using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class DataSaver
{
    public List<string> PrimitivesNames;

    public List<string> GetPrimitivesNames()
    {
        TextAsset primitivesNames = Resources.Load("primitivesNames") as TextAsset;
        string primitivesJson = primitivesNames.text;

        return JsonUtility.FromJson<DataSaver>(primitivesJson).PrimitivesNames;
    }
}
