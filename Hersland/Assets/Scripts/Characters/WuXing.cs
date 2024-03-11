using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.UI;
using HL.Characters.Properties;
using static HL.Characters.Properties.PropertiesManager;

namespace HL.Characters
{
    public class WuXing : MonoBehaviour
    {
        

        public float maxStat = 100;
        public float minStat = 0;


        public Dictionary<WuXingType, float> wuXingStatsDictionary = new Dictionary<WuXingType, float>();
        public Dictionary<WuXingType, float> wuXingCapStatsDictionary = new Dictionary<WuXingType, float>();

        // cap
        public float jinCap = 80f;
        public float muCap = 50f;
        public float shuiCap = 50f;
        public float huoCap = 50f;
        public float tuCap = 50f;

        public float jin = 80f;
        public float mu = 50f;
        public float shui = 50f;
        public float huo = 50f;
        public float tu = 50f;

        //Wu Xing radar chart
        [SerializeField] private GameObject characterRadarChartPanelPrefab;


        private void Awake()
        {
            InitializeWuXingStatsDictionary();
            SetUpWuXingCapStatsDictionary();
        }


        public void InitializeWuXingStatsDictionary()
        {
            
            wuXingStatsDictionary.Add(WuXingType.Jin, jin);
            wuXingStatsDictionary.Add(WuXingType.Mu, mu);
            wuXingStatsDictionary.Add(WuXingType.Shui, shui);
            wuXingStatsDictionary.Add(WuXingType.Huo, huo);
            wuXingStatsDictionary.Add(WuXingType.Tu, tu);
        }

        public void SetUpWuXingCapStatsDictionary()
        {
            wuXingCapStatsDictionary.Add(WuXingType.Jin, jinCap);
            wuXingCapStatsDictionary.Add(WuXingType.Mu, muCap);
            wuXingCapStatsDictionary.Add(WuXingType.Shui, shuiCap);
            wuXingCapStatsDictionary.Add(WuXingType.Huo, huoCap);
            wuXingCapStatsDictionary.Add(WuXingType.Tu, tuCap);
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
            jin = jinCap * 0.3f;
            mu = muCap * 0.3f;
            shui = shuiCap * 0.3f;
            huo = huoCap * 0.3f;
            tu = tuCap * 0.3f;
        }

        public void DisplayWuXingCap(Transform transform)
        {
            characterRadarChartPanelPrefab = Resources.Load<GameObject>("Wu Xing Radar Chart Panel");
            if (characterRadarChartPanelPrefab is null)
            {
                Debug.Log("null");
            }
            GameObject wuXingCapChartPanel = Instantiate(characterRadarChartPanelPrefab, transform);
            RadarChartMesh wuXingMesh = wuXingCapChartPanel.GetComponentInChildren<RadarChartMesh>();
            float[] wuXingCapArray = GetWuXingCapArray();
            wuXingMesh.GenerateRadarMesh(wuXingCapArray, 100);
            
        }

        public void DisplayWuXing(Transform transform)
        {
            characterRadarChartPanelPrefab = Resources.Load<GameObject>("Wu Xing Radar Chart Panel");
            if (characterRadarChartPanelPrefab is null)
            {
                Debug.Log("null");
            }
            GameObject wuXingCapChartPanel = Instantiate(characterRadarChartPanelPrefab, transform);
            RadarChartMesh wuXingMesh = wuXingCapChartPanel.GetComponentInChildren<RadarChartMesh>();
            float[] wuXingCapArray = GetWuXingArray();
            wuXingMesh.GenerateRadarMesh(wuXingCapArray, 100);

        }
    }


    
}