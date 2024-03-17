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
        public TextMeshProUGUI worldSizeTMP;
        public TextMeshProUGUI populationTMP;

        private void Start()
        {
            if (worldInfo == null)
            {
                worldInfo = GameObject.Find("World Information").GetComponent<WorldInfo>();
            }
            UpdateWorldInfoText();
        }


        // Update Info text
        public void UpdateWorldInfoText()
        {
            string worldSizeString = I2.Loc.LocalizationManager.GetTranslation(worldInfo.worldSize.ToString());
            worldSizeTMP.text = worldSizeString;

            string population = I2.Loc.LocalizationManager.GetTranslation(worldInfo.population.ToString());
            populationTMP.text = population;
        }




        // World Size Adjustment
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

        



        // Population Adjustment
        public void NextPopulation()
        {
            worldInfo.NextPopulation();
            UpdateWorldInfoText();

        }

        public void LastPopulation()
        {
            worldInfo.LastPopulation();
            UpdateWorldInfoText();
        }





    }
}