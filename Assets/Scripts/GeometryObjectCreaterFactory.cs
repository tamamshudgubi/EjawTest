using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeometryObjectCreaterFactory : MonoBehaviour
{
    [SerializeField] private Spawner _touchHandler;
    [SerializeField] private Image _color;
    [SerializeField] private TMP_Text _figureName;
    [SerializeField] private TMP_Text _clicksAmount;

    [SerializeField] private ClickCounter _clickCounter;


    private void OnEnable()
    {
        _touchHandler.GeometryObjectCreating += OnGeometryObjectCreating;
    }

    private void OnDisable()
    {
        _touchHandler.GeometryObjectCreating -= OnGeometryObjectCreating;
    }

    public void OnGeometryObjectCreating(GameObject geometryObjectShape, Vector3 postion)
    {
        GeometryObjectModel geometryObject = Instantiate(geometryObjectShape, postion + new Vector3(0, 0, 10), Quaternion.identity).GetComponent<GeometryObjectModel>();

        geometryObject.Initialize(_clickCounter, _color, _figureName, _clicksAmount);
    }
}
