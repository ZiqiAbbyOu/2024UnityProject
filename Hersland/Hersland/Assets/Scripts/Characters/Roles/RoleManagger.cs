using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HL.Characters.Roles {
    public class RoleManager : MonoBehaviour
    {
        public enum RoleType
        {
            MartialArtist,
            Doctor,
            Dancer,
            Teacher,
            Poet,
            Wanderer,
            Default,

        }
        public static RoleManager Instance { get; set; }
        public Dictionary<RoleType, RoleInfo> roleInfoDictionary = new Dictionary<RoleType, RoleInfo>();
        //public RoleTypes.RoleType selectedRole;
        [SerializeField] private RoleInfo martialArtistInfo;
        [SerializeField] private RoleInfo poetInfo;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                InitializeRoleInfo();
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        void InitializeRoleInfo()
        {
            // Adding roles

            roleInfoDictionary.Add(RoleType.MartialArtist, martialArtistInfo);

            roleInfoDictionary.Add(RoleType.Poet, poetInfo);

        }

        public RoleInfo GetRoleInfo(RoleType roleType)
        {
            if(roleInfoDictionary. ContainsKey(roleType))
            {
                return roleInfoDictionary[roleType];
            }

            else
            {
                Debug.LogWarning($"RoleInfo for {roleType} not found.");
                return null;
            }
        }

        public int GetRolesCount()
        {
            return roleInfoDictionary.Count;
        }

        public IEnumerable<RoleInfo> GetAllRoleInfos()
        {
            return roleInfoDictionary.Values;
        }

    }
}