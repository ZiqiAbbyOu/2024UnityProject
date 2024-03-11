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
        [SerializeField] private GameObject adjustmentUIGameObject;
        [SerializeField] private PropertiesManager.WuXingType currentWuXingType;
        [SerializeField] private WuXingRadarChartController wuXingRadarChartController;
        public Button[] elementButtons = new Button[5];
        HL.Characters.CharacterInfo playerInfo;
        public TMP_InputField statsInputField;

        private void Start()
        {

            // Get user info
            playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();

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
                elementButtons[i].onClick.AddListener(() => OnElementButtonClicked(index));


            }

            

        }

        // buttons event
        private void OnElementButtonClicked(int index)
        {

            switch (index)
            {
                case 0:
                    currentWuXingType = PropertiesManager.WuXingType.Jin;
                    break;
                case 1:
                    currentWuXingType = PropertiesManager.WuXingType.Mu;
                    break;

                case 2:
                    currentWuXingType = PropertiesManager.WuXingType.Shui;
                    break;

                case 3:
                    currentWuXingType = PropertiesManager.WuXingType.Huo;
                    break;

                case 4:
                    currentWuXingType = PropertiesManager.WuXingType.Tu;
                    break;

            }

            

            adjustmentUIGameObject.SetActive(true);

            // Set input file
            statsInputField = GameObject.Find("Wu Xing Stats InputField (TMP)").GetComponent<TMP_InputField>();
            statsInputField.text = ((int)playerInfo.wuXing.GetWuXingCapStatsByType(currentWuXingType)).ToString();
            Debug.Log(currentWuXingType);
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
            adjustmentUIGameObject.SetActive(true);
        }

        public void IncreaseCurrentWuXingElementCapByOne()
        {
            playerInfo.wuXing.IncreaseWuXingCapStatsByType(currentWuXingType);
        }

        public void DecreaseCurrentWuXingElementCapByOne()
        {
            playerInfo.wuXing.IncreaseWuXingCapStatsByType(currentWuXingType);
        }

        public void LogInput()
        {
            Debug.Log(statsInputField.text);
        }


    }
}