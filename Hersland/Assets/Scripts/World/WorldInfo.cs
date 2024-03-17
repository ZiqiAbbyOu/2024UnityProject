using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HL.World
{
    public class WorldInfo : MonoBehaviour
    {
        public static WorldInfo Instance;

        public enum WorldSize
        {
            Small,
            Median,
            Large
        }

        public enum Population
        {
            Sparse,
            Normal,
            Crowded
        }

        [SerializeField] public WorldSize worldSize;
        [SerializeField] public Population population;
        [SerializeField] public int society;



        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitiateWorldInfo();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitiateWorldInfo()
        {
            //Set up default world information
            worldSize = WorldSize.Median;
            population = Population.Normal;
            society = 5;
        }

        public void NextWorldSize()
        {
            int valuesCount = System.Enum.GetValues(typeof(WorldSize)).Length;
            worldSize = (WorldSize)(((int)worldSize + 1 + valuesCount) % valuesCount);
        }

        public void LastWorldSize()
        {
            int valuesCount = System.Enum.GetValues(typeof(WorldSize)).Length;
            worldSize = (WorldSize)(((int)worldSize - 1 + valuesCount) % valuesCount);
        }

        public void NextPopulation()
        {
            int valuesCount = System.Enum.GetValues(typeof(Population)).Length;
            population = (Population)(((int)population + 1 + valuesCount) % valuesCount);
        }

        public void LastPopulation()
        {
            int valuesCount = System.Enum.GetValues(typeof(Population)).Length;
            population = (Population)(((int)population - 1 + valuesCount) % valuesCount);
        }
    }
}