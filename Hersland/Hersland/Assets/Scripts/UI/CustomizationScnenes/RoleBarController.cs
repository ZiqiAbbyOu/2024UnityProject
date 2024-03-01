using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters;
using UnityEngine.UI;

namespace HL.UI.CustomizationScene
{
    public class RoleBarController : MonoBehaviour
    {
        public RoleBar roleBar;
        public Button roleBarButton;
        [SerializeField] private RoleSelectionController roleSelectionController;

        private void Start()
        {
            roleBar = GetComponent<RoleBar>();
            roleBarButton = GetComponent<Button>();
            roleSelectionController = GameObject.Find("Game Manager").GetComponent<RoleSelectionController>();
            roleBarButton.onClick.AddListener(OnRoleBarButtonClicked);
            
        }

        private void OnRoleBarButtonClicked()
        {
            RoleDescriptionUIManager.Instance.currentSelectedRole = roleBar.roleType;
            roleSelectionController.SetSelectedRole(roleBar.roleType);
            roleSelectionController.DisplayRoleSelection();
            roleSelectionController.SetDefaultMode();

        }

        public void SetPlayerRole()
        {
            HL.Characters.CharacterInfo playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();
            playerInfo.SetCharacterRole(roleBar.roleType);
        }
    }
}