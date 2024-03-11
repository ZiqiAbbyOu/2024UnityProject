using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HL.Characters.Properties
{
    public class PropertiesManager : MonoBehaviour
    {

        public class WuXingInfo : MonoBehaviour
        {
            public string wuXingName;
            public string description;
        }

        public enum WuXingType
        {
            Jin,
            Mu,
            Shui,
            Huo,
            Tu
        }


        public static PropertiesManager Instance { get; set; }
        public Dictionary<WuXingType, WuXingInfo> wuXingDictionary = new Dictionary<WuXingType, WuXingInfo>();





        // Start is called before the first frame update
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                SetUpWuXingDictionary();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        void SetUpWuXingDictionary()
        {

            //Default
            WuXingInfo defaultInfo = gameObject.AddComponent<WuXingInfo>();
            defaultInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Default_Name");
            defaultInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Default_Description");

            //Jin
            WuXingInfo jinInfo = gameObject.AddComponent<WuXingInfo>();
            jinInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Jin_Name");
            jinInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Jin_Description");

            //Mu
            WuXingInfo muInfo = gameObject.AddComponent<WuXingInfo>();
            muInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Mu_Name");
            muInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Mu_Description");

            //Shui
            WuXingInfo shuiInfo = gameObject.AddComponent<WuXingInfo>();
            shuiInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Shui_Name");
            shuiInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Shui_Description");

            //Huo
            WuXingInfo huoInfo = gameObject.AddComponent<WuXingInfo>();
            huoInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Huo_Name");
            huoInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Huo_Description");

            //Tu
            WuXingInfo tuInfo = gameObject.AddComponent<WuXingInfo>();
            tuInfo.wuXingName = I2.Loc.LocalizationManager.GetTranslation("WuXing_Tu_Name");
            tuInfo.description = I2.Loc.LocalizationManager.GetTranslation("WuXing_Tu_Description");

            wuXingDictionary.Add(WuXingType.Jin, jinInfo);
            wuXingDictionary.Add(WuXingType.Mu, muInfo);
            wuXingDictionary.Add(WuXingType.Shui, shuiInfo);
            wuXingDictionary.Add(WuXingType.Huo, huoInfo);
            wuXingDictionary.Add(WuXingType.Tu, tuInfo);
            //Debug.Log(defaultInfo.description + I2.Loc.LocalizationManager.GetTranslation("WuXing_Jin_Description"));

        }








    }
}