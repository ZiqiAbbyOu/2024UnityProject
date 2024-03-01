using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.UI;

namespace HL.Characters
{
    public class WuXing : MonoBehaviour
    {

        public float maxStat = 100;
        public float minStat = 0;

        // cap
        public float jinCap = 50f;
        public float muCap = 50f;
        public float shuiCap = 50f;
        public float huoCap = 50f;
        public float tuCap = 50f;

        public float jin = 50f;
        public float mu = 50f;
        public float shui = 50f;
        public float huo = 50f;
        public float tu = 50f;

        //Wu Xing radar chart
        [SerializeField] private GameObject characterRadarChartPanelPrefab;

        public float[] GetWuXingArray()
        {
            float[] wuXing = new float[5];
            wuXing[0] = jin;
            wuXing[1] = mu;
            wuXing[2] = shui;
            wuXing[3] = huo;
            wuXing[4] = tu;

            return wuXing;
        }

        public float[] GetWuXingCapArray()
        {
            float[] wuXing = new float[5];
            wuXing[0] = jinCap;
            wuXing[1] = muCap;
            wuXing[2] = shuiCap;
            wuXing[3] = huoCap;
            wuXing[4] = tuCap;
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
    }


    
}