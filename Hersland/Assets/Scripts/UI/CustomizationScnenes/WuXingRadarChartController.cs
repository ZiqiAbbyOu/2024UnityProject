using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HL.Characters;
using System;
using HL.Characters.Properties;
using HL.UI.CustomizationScene;

namespace HL.UI {
    public class WuXingRadarChartController : MonoBehaviour
    {
        [SerializeField] private Button[] elementButton;
        public TextMeshProUGUI element;
        public TextMeshProUGUI elementDiscription;
        [SerializeField] private PropertiesManager.WuXingType currentType;


        private void Start()
        {
            for (int i = 0; i < elementButton.Length; i++)
            {
                int index = i; 
                elementButton[i].onClick.AddListener(() => OnElementButtonClicked(index));
            }
        }




        // particularly for customization scene
        private void OnElementButtonClicked(int index)
        {
            switch (index)
            {
                case 0:
                    currentType = PropertiesManager.WuXingType.Jin;
                    break;
                case 1:
                    currentType = PropertiesManager.WuXingType.Mu;
                    break;

                case 2:
                    currentType = PropertiesManager.WuXingType.Shui;
                    break;

                case 3:
                    currentType = PropertiesManager.WuXingType.Huo;
                    break;

                case 4:
                    currentType = PropertiesManager.WuXingType.Tu;
                    break;

            }
            DisplayDiscription();
        }

        public Button[] GetButtons()
        {
            if (elementButton is null)
            {
                Debug.Log("null");
            }
            return elementButton;
        }

        public void EnableButton()
        {
            foreach (Button button in elementButton)
            {
                button.interactable = true;
            }
        }

        public void DisableButton()
        {
            foreach (Button button in elementButton)
            {
                button.interactable = false;
            }
        }

        public void DisplayDiscription()
        {
            PropertiesManager propertiesManager = PropertiesManager.Instance;
            PropertiesManager.WuXingInfo currentWuXingInfo = propertiesManager.wuXingDictionary[currentType];
            element.text = currentWuXingInfo.wuXingName;
            elementDiscription.text = currentWuXingInfo.description;
        }

    }

}