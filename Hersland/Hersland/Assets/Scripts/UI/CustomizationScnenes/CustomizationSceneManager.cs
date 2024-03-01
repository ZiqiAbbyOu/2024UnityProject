using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using HL.Characters;
using HL.Characters.Roles;
using TMPro;

namespace HL.GameManager
{
    public class CustomizationSceneManager : MonoBehaviour
    {
        public Transform wuXingPanelTransform;

        private void Start()
        {

            // Get user info
            HL.Characters.CharacterInfo playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();

            // Display Wu Xing Chart
            WuXing playerWuXing = playerInfo.wuXing;
            playerWuXing.DisplayWuXingCap(wuXingPanelTransform);
            SetUpWuXingRadarChartDiscription();

            // Display Role Bar
            RoleManager roleManager = GameObject.Find("Roles Manager").GetComponent<RoleManager>();
            foreach(RoleInfo roleInfo in roleManager.GetAllRoleInfos()){
                
            }

        }



        private void SetUpWuXingRadarChartDiscription()
        {
            WuXingRadarChartController wuXingRadarChartController = GameObject.Find("Wu Xing Radar Chart Panel(Clone)").GetComponent<WuXingRadarChartController>();
            if (wuXingRadarChartController == null)
            {
                Debug.LogWarning("Wu Xing Radar Chart Controller Haven't Set up");
            }
            else{
                GameObject wuXingDescription = GameObject.Find("Wu Xing Description");
                wuXingRadarChartController.elementDiscription = GameObject.Find("Wu Xing Description").GetComponent<TextMeshProUGUI>();
            }
        }

    }
}