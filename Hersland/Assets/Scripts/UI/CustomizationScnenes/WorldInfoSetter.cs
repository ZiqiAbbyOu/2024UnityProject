using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.World;
using TMPro;

namespace HL.UI.CustomizationScene
{
    public class WorldInfoSetter : MonoBehaviour
    {
        public WorldInfo worldInfo = WorldInfo.Instance;
        public TextMeshProUGUI worldSizeText;

        private void Start()
        {
            if (worldInfo == null)
            {
                worldInfo = GameObject.Find("World Information").GetComponent<WorldInfo>();
            }
            UpdateWorldInfoText();
        }

        public void NextWorldSize()
        {
            worldInfo.NextWorldSize();
            UpdateWorldInfoText();

        }

        public void LastWorldSize()
        {
            worldInfo.LastWorldSize();
            UpdateWorldInfoText();
        }

        public void UpdateWorldInfoText()
        {
            string worldSizeString = I2.Loc.LocalizationManager.GetTranslation(worldInfo.worldSize.ToString());
            worldSizeText.text = worldSizeString;
        }


    }
}