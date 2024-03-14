using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.UI;
using HL.Characters.Properties;
using static HL.Characters.Properties.PropertiesManager;
using System;

namespace HL.Characters
{
    public class WuXing : MonoBehaviour
    {
        

        public float maxStat = 100;
        public float minStat = 0;

        public Dictionary<WuXingType, float> wuXingStatsDictionary = new Dictionary<WuXingType, float>();
        public Dictionary<WuXingType, float> wuXingCapStatsDictionary = new Dictionary<WuXingType, float>();


        //cap
        //[SerializeField] private float jinCap;
        //[SerializeField] private float muCap;
        //[SerializeField] private float shuiCap;
        //[SerializeField] private float huoCap;
        //[SerializeField] private float tuCap;

        //[SerializeField] private float jin;
        //[SerializeField] private float mu;
        //[SerializeField] private float shui;
        //[SerializeField] private float huo;
        //[SerializeField] private float tu;

        //Wu Xing radar chart
        //[SerializeField] private GameObject characterRadarChartPanelPrefab;


        private void Awake()
        {
            InitializeWuXingStatsDictionary();
            SetUpWuXingCapStatsDictionary();
            SetStatsByCap();
        }


        public void InitializeWuXingStatsDictionary()
        {
            
            wuXingStatsDictionary.Add(WuXingType.Jin, 50);
            wuXingStatsDictionary.Add(WuXingType.Mu, 50);
            wuXingStatsDictionary.Add(WuXingType.Shui, 50);
            wuXingStatsDictionary.Add(WuXingType.Huo, 50);
            wuXingStatsDictionary.Add(WuXingType.Tu, 50);
        }

        public void SetUpWuXingCapStatsDictionary()
        {
            wuXingCapStatsDictionary.Add(WuXingType.Jin, 50);
            wuXingCapStatsDictionary.Add(WuXingType.Mu, 50);
            wuXingCapStatsDictionary.Add(WuXingType.Shui, 50);
            wuXingCapStatsDictionary.Add(WuXingType.Huo, 50);
            wuXingCapStatsDictionary.Add(WuXingType.Tu, 50);
        }

        public void ResetStatsDictionary(Dictionary<WuXingType, float> statsDictionary, WuXingType wuXingType, float stats)
        {
            statsDictionary[wuXingType] = stats;
        }

        public float GetWuXingCapStatsByType(PropertiesManager.WuXingType wuXingType)
        {
            float wuXingCapStats = wuXingCapStatsDictionary[wuXingType];

            return wuXingCapStats;
        }

        public void IncreaseWuXingCapStatsByType(PropertiesManager.WuXingType wuXingType)
        {
            wuXingCapStatsDictionary[wuXingType] += 1.0f;
        }

        public void DecreaseWuXingCapStatsByType(PropertiesManager.WuXingType wuXingType)
        {
            wuXingCapStatsDictionary[wuXingType] -= 1.0f;
        }

        public float GetWuXingcapStat(WuXingType wuXingType)
        {
            float capStat = 0.0f;
            capStat = wuXingCapStatsDictionary[wuXingType];

            return capStat;
        }




        public float[] GetWuXingArray()
        {
            float[] wuXing = new float[5];
            wuXing[0] = wuXingStatsDictionary[WuXingType.Jin];
            wuXing[1] = wuXingStatsDictionary[WuXingType.Mu];
            wuXing[2] = wuXingStatsDictionary[WuXingType.Shui];
            wuXing[3] = wuXingStatsDictionary[WuXingType.Huo];
            wuXing[4] = wuXingStatsDictionary[WuXingType.Tu];

            return wuXing;
        }

        public float[] GetWuXingCapArray()
        {
            float[] wuXing = new float[5];
            wuXing[0] = wuXingCapStatsDictionary[WuXingType.Jin];
            wuXing[1] = wuXingCapStatsDictionary[WuXingType.Mu];
            wuXing[2] = wuXingCapStatsDictionary[WuXingType.Shui];
            wuXing[3] = wuXingCapStatsDictionary[WuXingType.Huo];
            wuXing[4] = wuXingCapStatsDictionary[WuXingType.Tu];
            return wuXing;
        }

        public void SetStatsByCap()
        {

            foreach(WuXingType wuXingType in Enum.GetValues(typeof (WuXingType))){

                wuXingStatsDictionary[wuXingType] = wuXingCapStatsDictionary[wuXingType] * 0.6f;

                Debug.Log(wuXingType + " " + wuXingStatsDictionary[wuXingType]);
            }


        }

        public void DisplayWuXingCap(Transform transform, RadarChartMesh characterWuXingCapMesh)
        {

            float[] wuXingCapArray = GetWuXingCapArray();
            characterWuXingCapMesh.GenerateRadarMesh(wuXingCapArray, (int)maxStat, transform);
            
        }

        public void DisplayWuXing(Transform transform, RadarChartMesh characterWuXingMesh)
        {
            float[] wuXingArray = GetWuXingArray();
            characterWuXingMesh.GenerateRadarMesh(wuXingArray, (int)maxStat, transform);


        }
    }


    
}