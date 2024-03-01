using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WuXingRadarChartController : MonoBehaviour
{
    [SerializeField] private Button[] elementButton;
    [SerializeField] public TextMeshProUGUI elementDiscription;


    public void EnableButton()
    {
        foreach(Button button in elementButton)
        {
            button.interactable = true;
        }
    }

    public void DisableButton()
    {
        foreach(Button button in elementButton)
        {
            button.interactable = false;
        }
    }

    public void DisplayDiscriptionDefault()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Default");
    }

    public void DisplayDiscriptionJin()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Jin");
    }

    public void DisplayDiscriptionMu()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Mu");
    }

    public void DisplayDiscriptionShui()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Shui");
    }

    public void DisplayDiscriptionHuo()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Huo");
    }

    public void DisplayDiscriptionTu()
    {
        elementDiscription.text = I2.Loc.LocalizationManager.GetTranslation("WuXing_Discription_Tu");
    }
}

