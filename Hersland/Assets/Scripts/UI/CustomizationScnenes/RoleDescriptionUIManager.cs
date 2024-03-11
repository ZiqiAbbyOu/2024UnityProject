using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using HL.Characters.Roles;
using static HL.Characters.Roles.RoleManager;

namespace HL.UI.CustomizationScene
{
    public class RoleDescriptionUIManager : MonoBehaviour
    {
        public static RoleDescriptionUIManager Instance { get; protected set; }
        public GameObject descriptionPrefab;
        public Transform UICanvas;
        private GameObject descriptionInstance;
        public RoleType currentSelectedRole;
        public bool descriptionWindowActive = false;
        private RoleDescriptionController roleDescriptionController;
        


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializeDescriptionPrefab();
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        public void InitializeDescriptionPrefab()
        {

            if (descriptionPrefab && UICanvas)
            {
                descriptionInstance = Instantiate(descriptionPrefab);
                descriptionInstance.SetActive(false);
                roleDescriptionController = descriptionInstance.GetComponentInChildren<RoleDescriptionController>();
            }
        }

        public void SetDescription()
        {
                roleDescriptionController.UpdateDescription(currentSelectedRole);
                descriptionInstance.SetActive(true);
        }
    }
}