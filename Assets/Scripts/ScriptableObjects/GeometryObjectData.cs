using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new GeometryObjectData", menuName = "GeometryObjectData")]
public class GeometryObjectData : ScriptableObject
{
    public List<ClickColorData> ClicksData;
}
