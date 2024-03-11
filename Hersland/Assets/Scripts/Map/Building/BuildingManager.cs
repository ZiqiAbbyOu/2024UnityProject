using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HL.Map.Building
{
    public class BuildingManager : MonoBehaviour
    {
        public enum BuildingType
        {
            MartialArtBuilding,
            Academy,
        }
        public static BuildingManager Instance { get; set; }
        public Dictionary<BuildingType, BuildingInfo> buildingDictionary = new Dictionary<BuildingType, BuildingInfo>();
        public BuildingInfo[] buildingInfos;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializeTileDictionary();
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeTileDictionary()
        {
            int count = 0;
            foreach (BuildingType buildingType in Enum.GetValues(typeof(BuildingType))){
                buildingDictionary.Add(buildingType, buildingInfos[count]);
                count++;

            }

        }
    }
}