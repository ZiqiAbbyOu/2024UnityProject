using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters.Roles;

namespace HL.UI.CustomizationScene
{
    public class RoleDisplayer : MonoBehaviour
    {
        public GameObject roleBarPrefab;
        private Transform rolesContainer;

        void Start()
        {
            if (RoleManager.Instance == null)
            {
                Debug.LogError("RoleManagger instance not found.");
                return;
            }

            var allRoles = RoleManager.Instance.GetAllRoleInfos();
            
            foreach (var roleInfo in allRoles)
            {
                rolesContainer = GameObject.Find("Role Bar Panel").GetComponent<Transform>();
                GameObject roleInstance = Instantiate(roleBarPrefab, rolesContainer);
                RoleBar roleBar = roleInstance.GetComponent<RoleBar>();
                roleBar.SetUpRoleBar(roleInfo.roleType);
                

            }

        }
    }
}