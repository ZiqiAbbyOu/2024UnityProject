using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HL.Characters;
using System;
using HL.Characters.Properties;




namespace HL.UI.CustomizationScene {

    // particularly for customization scene
    public class CustomizationSceneWuXingRadarChartController : MonoBehaviour
    {
        [SerializeField] private Button[] elementButton;
        public TextMeshProUGUI element;
        public TextMeshProUGUI elementDiscription;
        [SerializeField] private PropertiesManager.WuXingType currentType;
        public HL.Characters.CharacterInfo playerInfo;


        private void Start()
        {
            playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();
            for (int i = 0; i < elementButton.Length; i++)
            {
                int index = i; 
                elementButton[i].onClick.AddListener(() => OnElementButtonClicked(index));
            }
        }




        
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

        


        public void DisplayStatsCapRadarChart(Transform wuXingDisplayChartTransform)
        {
            RadarChartMesh radarChartMesh = GameObject.Find("Wu Xing Radar Chart Panel(clone)").GetComponent<RadarChartMesh>();
            radarChartMesh.displayChartTransform = wuXingDisplayChartTransform;
            radarChartMesh.GenerateRadarMesh(playerInfo.wuXing.GetWuXingCapArray(), (int)playerInfo.wuXing.maxStat);
        }

        public void SetCharacterInfo(HL.Characters.CharacterInfo thisCharacterInfo)
        {
            playerInfo = thisCharacterInfo;
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}