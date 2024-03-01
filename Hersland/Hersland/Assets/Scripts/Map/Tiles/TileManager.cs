using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace HL.Map.Tiles
{
    public class TileManager : MonoBehaviour
    {
        public enum TileType
        {
            Grassland,
        }
        public static TileManager Instance { get; set; }
        public Dictionary<TileType, TileInfo> tileDictionary = new Dictionary<TileType, TileInfo>();
        public TileInfo grasslandInfo;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializeTileDictionary();
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeTileDictionary()
        {
            tileDictionary.Add(TileType.Grassland, grasslandInfo);
        }
    }
}