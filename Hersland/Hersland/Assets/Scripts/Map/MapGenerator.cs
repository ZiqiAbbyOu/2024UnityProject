using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HL.Characters.Roles;
using HL.Map.Tiles;
using HL.Map.Building;
using HL.Characters;
using static HL.Map.Building.BuildingManager;
using static HL.Characters.Roles.RoleManager;
using static HL.Map.Tiles.TileManager;


// generate tile, building, and characters
namespace HL.Map
{
    public class MapGenerator : MonoBehaviour
    {

        // tilemap
        [SerializeField] public IsometricRuleTile isometricRuleTile;
        public Tilemap tilemap;
        public Tilemap buildingTilemap;
        public Vector2Int initialMapSize = new Vector2Int(3, 3);
        public Transform tileContainer;


        // tiles
        private Dictionary<TileType, TileInfo> tilesDictionary;
        [SerializeField]private GameObject tilePrefab;

        // buildings
        public GameObject buildingPrefab;

        //player
        public HL.Characters.CharacterInfo playerInfo;
        public RoleType roleType;



        // Start is called before the first frame update
        void Start()
        {
            if (RoleManager.Instance == null)
            {
                GameObject gameManager = GameObject.Find("Game Manager");
                gameManager.AddComponent<RoleManager>();
            }
            HL.Characters.CharacterInfo playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();
            roleType = playerInfo.characterRole;
            tilesDictionary = TileManager.Instance.tileDictionary;
            GenerateInitialMap();
            SpawnRoleBuilding();

        }


        // tiles
        public void GenerateInitialMap()
        {
            
            for (int x = 0; x < initialMapSize[0]; x++)
            {
                for (int y = 0; y < initialMapSize[1]; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    TileInfo selectedTileInfo = selectRandomTileInfo();
                    if(selectedTileInfo != null)
                    {
                        tilemap.SetTile(tilePosition, isometricRuleTile);
                        CreateTileGameObject(tilePosition, selectedTileInfo);
                    }


                }
            }
        }

        public TileInfo selectRandomTileInfo()
        {
            if (tilesDictionary.Count == 0)
            {
                return null;
            }
            else
            {
                List<TileInfo> tileInfos = new List<TileInfo>(tilesDictionary.Values);
                return tileInfos[Random.Range(0, tileInfos.Count)];
            }
        }

       


        //buildings
        public void SpawnRoleBuilding()
        {

            if (playerInfo is null)
            {
                playerInfo = GameObject.Find("Player").GetComponent<HL.Characters.CharacterInfo>();
            }
            RoleInfo roleInfo;
            RoleManager.Instance.roleInfoDictionary.TryGetValue(roleType,out roleInfo);
            BuildingType roleBuilding = roleInfo.roleBuilding;
            BuildingInfo roleBuildingInfo;
            BuildingManager.Instance.buildingDictionary.TryGetValue(roleBuilding, out roleBuildingInfo);
            IsometricRuleTile buildingTile = roleBuildingInfo.buildingTile;
            Vector3Int tilePosition = new Vector3Int(Random.Range(1, initialMapSize[0]), Random.Range(1, initialMapSize[1]), 0);

            buildingTilemap.SetTile(tilePosition, buildingTile);
            GameObject tile = GameObject.Find($"Tile_{tilePosition.x - 1}_{tilePosition.y - 1}");
            AddBuildingToTile(roleBuildingInfo, tile);



            playerInfo.SetInitialPosition(tilePosition);

        }


        //tile object that stores tile information including the building and characters on the tile
        private void CreateTileGameObject(Vector3Int tilePosition, TileInfo tileInfo)
        {
            if (tilePrefab != null)
            {
                Vector3 worldPosition = tilemap.CellToWorld(tilePosition) + new Vector3(0, 3 * tilemap.cellSize.y / 2, 0);
                GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity, tileContainer);
                tile.name = $"Tile_{tilePosition.x}_{tilePosition.y}";
                TileInfo thisTileInfo = tile.AddComponent<TileInfo>();
                thisTileInfo.SetNewTileInfo(tileInfo);
            }
        }

        private void AddBuildingToTile(BuildingInfo buildingInfo, GameObject tile)
        {
            GameObject building = Instantiate(buildingPrefab, tile.transform);
            BuildingInfo newBuildingInfo = building.AddComponent<BuildingInfo>();
            newBuildingInfo.SetNewBuildingInfo(buildingInfo);
            building.name = newBuildingInfo.buildingType.ToString();

        }



    }
}