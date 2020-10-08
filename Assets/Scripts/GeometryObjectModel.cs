using UnityEngine;
using UniRx;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GeometryObjectModel : MonoBehaviour
{
    [SerializeField] private int _clicks;
    [SerializeField] private GeometryObjectData _geometryObjectData;
    [SerializeField] private ClickCounter _clickCounter;

    private Material _material;
    private List<ClickColorData> _clicksColorData;

    private Image _color;
    private TMP_Text _figureName;
    private TMP_Text _clicksAmount;


    private void Start()
    {
        _clickCounter.Clicked += OnClicked;
        _clicksColorData = _geometryObjectData.ClicksData;
        _material = GetComponent<MeshRenderer>().material;

        GameData gameData = Resources.Load<GameData>("GameData/AdminSettings");

        Observable.Timer(System.TimeSpan.FromSeconds(gameData.ObservableTime))
        .Repeat()
        .Subscribe(_ =>
            ChageColorByTime()
        );
    }

    private void Update()
    {
        UpdateControlStats(_material.color, _clicksColorData[0].ObjectType, _clicks.ToString());
    }

    private void OnDisable()
    {
        _clickCounter.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        CheckClickColorData(_clicksColorData);
        IncreaseClicksAmount();
    }

    private void CheckClickColorData(List<ClickColorData> clickColorData)
    {
        foreach (var data in clickColorData)
        {
            if (_clicks >= data.MinClicksCount && _clicks <= data.MaxClicksCount)
            {
                ChangeColorByClick(data.Color);
            }
        }
    }

    private void ChageColorByTime()
    {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        _material.color = newColor;
    }

    private void ChangeColorByClick(Color color)
    {
        _material.color = color;
    }

    private void IncreaseClicksAmount()
    {
        _clicks++;
    }

    private void UpdateControlStats(Color color, string objectType, string clicks)
    {
        _color.color = color;
        _figureName.text = objectType;
        _clicksAmount.text = clicks;
    }

    public void Initialize(ClickCounter counter, Image color, TMP_Text figureName, TMP_Text clicks)
    {
        _clickCounter = counter;
        _color = color;
        _figureName = figureName;
        _clicksAmount = clicks;
    }
}
