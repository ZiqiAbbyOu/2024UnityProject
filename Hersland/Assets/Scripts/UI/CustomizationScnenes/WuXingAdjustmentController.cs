using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters;
using HL.Characters.Roles;
using TMPro;
using HL.Characters.Properties;
using UnityEngine.UI;
using System;

namespace HL.UI.CustomizationScene
{
    public class WuXingAdjustmentController : MonoBehaviour
    {
        public Transform wuXingPanelTransform;
        [SerializeField] private GameObject adjustmentGameObject;
        [SerializeField] private PropertiesManager.WuXingType currentWuXing;
        [SerializeField] private WuXingRadarChartController wuXingRadarChartController;
        public Button[] elementButtons = new Button[5];
        public InputField statsInputField;

        private void Start()
        {

            // Get user info
            HL.Characters.CharacterInfo playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();

            // Display Wu Xing Chart
            WuXing playerWuXing = playerInfo.wuXing;
            playerWuXing.DisplayWuXingCap(wuXingPanelTransform);
            SetUpWuXingRadarChartDiscription();


            // listen to the element Buttons;

            wuXingRadarChartController = GameObject.Find("Wu Xing Radar Chart Panel(Clone)").GetComponent<WuXingRadarChartController>();
            
            elementButtons = wuXingRadarChartController.GetButtons();


            for (int i = 0; i < elementButtons.Length; i++)
            {
                int index = i;
                elementButtons[i].onClick.AddListener(() => OnElementButtonClicked(i));


            }

        }

        private void OnElementButtonClicked(int index)
        {

            switch (index)
            {
                case 0:
                    currentWuXing = PropertiesManager.WuXingType.Jin;
                    break;
                case 1:
                    currentWuXing = PropertiesManager.WuXingType.Mu;
                    break;

                case 2:
                    currentWuXing = PropertiesManager.WuXingType.Shui;
                    break;

                case 3:
                    currentWuXing = PropertiesManager.WuXingType.Huo;
                    break;

                case 4:
                    currentWuXing = PropertiesManager.WuXingType.Tu;
                    break;

            }

            adjustmentGameObject.SetActive(true);
        }

        private void SetUpWuXingRadarChartDiscription()
        {
            WuXingRadarChartController wuXingRadarChartController = GameObject.Find("Wu Xing Radar Chart Panel(Clone)").GetComponent<WuXingRadarChartController>();
            if (wuXingRadarChartController == null)
            {
                Debug.LogWarning("Wu Xing Radar Chart Controller Haven't Set up");
            }
            else
            {
                GameObject wuXingDescription = GameObject.Find("Wu Xing Description");
                wuXingRadarChartController.elementDiscription = GameObject.Find("Wu Xing Description (Text)").GetComponent<TextMeshProUGUI>();
                wuXingRadarChartController.element = GameObject.Find("Wu Xing Element (Text)").GetComponent<TextMeshProUGUI>();
            }
        }

        public void ShowsAdjustmentGameObject()
        {
            adjustmentGameObject.SetActive(true);
        }

        public void IncreaseCurrentWuXingCapByOne()
        {
            
        }

        public void LogInput()
        {
            Debug.Log(statsInputField.text);
        }


    }
}