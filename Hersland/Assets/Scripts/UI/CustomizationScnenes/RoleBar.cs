using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using HL.Characters.Roles;
using static HL.Characters.Roles.RoleManager;

namespace HL.UI.CustomizationScene
{
    public class RoleBar : MonoBehaviour
    {
        public TextMeshProUGUI roleName;
        public Image roleProtrait;
        public RoleType roleType;

        private void Start()
        {
            SetUpRoleBar(roleType);
        }


        public void SetUpRoleBar(RoleType inputRoleType)
        {
            this.roleType = inputRoleType;
            if (RoleManager.Instance != null) {

                RoleInfo roleInfo = RoleManager.Instance.GetRoleInfo(roleType);
                


                if (roleInfo != null)
                {
                    string roleNameKey = roleInfo.roleNameKey;
                    roleName.text = I2.Loc.LocalizationManager.GetTranslation(roleNameKey); // set up role name
                    roleProtrait.sprite = roleInfo.rolePortrait;
                }
                else
                {
                    Debug.Log($"RoleInfo for {roleType} is null.");
                }
            }
            else
            {
                Debug.Log("Instance is null");
            }
        }

        public void UpdateRoleNameUI(string newName)
        {
            roleName.text = newName;
        }

    }
}