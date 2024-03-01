using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters.Roles;
using TMPro;
using static HL.Characters.Roles.RoleManager;

namespace HL.UI.CustomizationScene {
    public class RoleDescriptionController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI roleTitle;
        [SerializeField] private TextMeshProUGUI roleDescription;
        private RoleType selectedRole;

        public void UpdateUI(string newTitle, string newDescription)
        {
            roleTitle.text = newTitle;
            roleDescription.text = newDescription;
        }



        public void UpdateDescription(RoleType roleType)
        {

            RoleInfo roleInfo = RoleManager.Instance.GetRoleInfo(roleType);
            string roleNameKey = roleInfo.roleNameKey;
            roleTitle.text = I2.Loc.LocalizationManager.GetTranslation(roleNameKey);
            string roleDescriptionKey = roleInfo.roleDescriptionKey;
            roleDescription.text = I2.Loc.LocalizationManager.GetTranslation(roleDescriptionKey);
            Canvas.ForceUpdateCanvases();
        }

        public void NextStage()
        {
            selectedRole = GameObject.Find("DescriptionUIManager").GetComponent<RoleDescriptionUIManager>().currentSelectedRole;
            SceneLoader sceneLoader = GetComponent<SceneLoader>();
            sceneLoader.LoadGameScene();
        }

        public void UpdateDescriptionUI(string newDescription)
        {
            roleTitle.text = newDescription;
        }

    }
}