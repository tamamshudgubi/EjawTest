using System;
using TMPro;
using UniRx;
using UnityEngine;

public class Help : MonoBehaviour
{
    [SerializeField] private TMP_Text _helpText;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("IsFirstTime"))
        {
            PlayerPrefs.SetInt("IsFirstTime", 1);
            ActivateHelpText();
        }
    }

    private void Start()
    {
        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(_ => IsFirstTimeInGame());
    }

    private void ActivateHelpText()
    {
        gameObject.SetActive(true);
    }

    private bool IsFirstTimeInGame()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("IsFirstTime")))
        {
            return true;
        }
        else
        {
            Destroy(gameObject);

            return false;
        }
    }
}
