using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HL.Map.Tiles.TileManager;

namespace HL.Map.Tiles
{
    public class TileInfo : MonoBehaviour
    {
        public TileType tileType;
        public string tileName;
        public Sprite tileSprite;

        public void SetNewTileInfo(TileInfo newTileInfo)
        {
            tileType = newTileInfo.tileType;
            tileName = newTileInfo.tileName;
            tileSprite = newTileInfo.tileSprite;

        }
    }

    
}