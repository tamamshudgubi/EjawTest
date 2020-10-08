using UnityEngine;

[CreateAssetMenu(fileName = "new ClickColorData", menuName = "ClickColoData")]
public class ClickColorData : ScriptableObject
{
    public string ObjectType;
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;
}
