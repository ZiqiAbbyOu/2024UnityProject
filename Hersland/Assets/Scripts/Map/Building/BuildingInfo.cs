using UnityEngine;
using System.Collections;
using static HL.Map.Building.BuildingManager;

namespace HL.Map.Building
{
    public class BuildingInfo : MonoBehaviour
    {
        public BuildingType buildingType;
        public string buildingNameKey;
        public IsometricRuleTile buildingTile;

        public void SetNewBuildingInfo(BuildingInfo newBuildingInfo)
        {
            buildingType = newBuildingInfo.buildingType;
            buildingNameKey = newBuildingInfo.buildingNameKey;
            buildingTile = newBuildingInfo.buildingTile;
    }
    }

    
}