using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters.Roles;
using UnityEngine.UI;
using HL.Characters;


namespace HL.UI.CustomizationScene {
    public class RoleSelectionController : MonoBehaviour
    {
        public enum SelectionMode
        {
            BackgroundRole,
            DreamRole,
            Default
        }

        [SerializeField]private SelectionMode selectionMode = SelectionMode.Default;
        public Image BackgroundRoleProtrait;
        public Image DreamRoleProtrait;
        [SerializeField] private HL.Characters.CharacterInfo playerInfo;
        [SerializeField] private RoleManager.RoleType selectedRole;

        private void Start()
        {
            SetDefaultMode();
            playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();
        }

        public void DisplayRoleSelection()
        {
           

            if (selectionMode == SelectionMode.BackgroundRole)
            {
                RoleInfo roleInfo = RoleManager.Instance.GetRoleInfo(selectedRole);
                BackgroundRoleProtrait.sprite = roleInfo.rolePortrait;
                playerInfo.SetCharacterRole(selectedRole);

            }

            if (selectionMode == SelectionMode.DreamRole)
            {
                RoleInfo roleInfo = RoleManager.Instance.GetRoleInfo(selectedRole);
                DreamRoleProtrait.sprite = roleInfo.rolePortrait;
                playerInfo.SetCharacterDreamRole(selectedRole);
            }

            if (selectionMode == SelectionMode.Default)
            {
                
                RoleDescriptionUIManager.Instance.SetDescription();
            }


        }

        public void SetSelectedRole(RoleManager.RoleType roleType)
        {
            selectedRole = roleType;
        }

        public void SetBackGroundRoleMode()
        {
            selectionMode = SelectionMode.BackgroundRole;
        }

        public void SetDreamRoleMode()
        {
            selectionMode = SelectionMode.DreamRole;
        }

        public void SetDefaultMode()
        {
            selectionMode = SelectionMode.Default;
        }

    }
}