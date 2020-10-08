using UniRx;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _geometryObjects;
    [SerializeField] private Camera _cameraMain;
    [SerializeField] private TMP_Text _geometryObjectName;

    private DataSaver _data = new DataSaver();
    private bool _isGeometryObjectsOnScene = false;

    public event Action<GameObject, Vector3> GeometryObjectCreating;


    private void Start()
    {
        _data.PrimitivesNames = _data.GetPrimitivesNames();

        Observable.EveryUpdate().
            Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => CheckIfInsideSpawnArea());
    }

    private void CheckIfInsideSpawnArea()
    {
        if (!_isGeometryObjectsOnScene)
        {
            Ray ray = _cameraMain.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.GetComponent<SpawnPlace>())
                {
                    TryToSpawn();
                }
            }
        }
    }

    private void TryToSpawn()
    {
        PlayerPrefs.SetInt("IsFirstTime", 0);
        _isGeometryObjectsOnScene = true;

        int random = UnityEngine.Random.Range(0, _geometryObjects.Count());
        Vector3 cursorWorldPostiion = _cameraMain.ScreenToWorldPoint(Input.mousePosition);
        string figureName = _data.PrimitivesNames.ElementAt(random);
        GameObject geometryObject = _geometryObjects.ElementAt(random);

        GeometryObjectCreating?.Invoke(geometryObject, cursorWorldPostiion);

        _geometryObjectName.text = figureName;
    }
}

