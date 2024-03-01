using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using HL.Map.Building;
using UnityEditor;
using static HL.Map.Building.BuildingManager;
using static HL.Characters.Roles.RoleManager;

namespace HL.Characters.Roles
{
    public class RoleInfo : MonoBehaviour
    {
        [SerializeField] public RoleType roleType;
        public RoleType dreamRoleType;
        public string roleNameKey;
        public string roleDescriptionKey;
        public Sprite rolePortrait;
        public BuildingType roleBuilding;
        

    }


}