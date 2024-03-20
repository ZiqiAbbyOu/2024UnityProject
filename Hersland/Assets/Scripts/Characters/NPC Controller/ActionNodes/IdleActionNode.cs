using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HL.Characters.NPCController
{
    public class IdleActionNode : ActionNode
    {
        private NPCController npcController;

        public IdleActionNode(NPCController npcController)
        {
            this.npcController = npcController;
        }


        public override void Evaluate()
        {

            // move only if it is not moving.
            // potentially an "Is Reach Idle Point"? 
            if (!npcController.isMoving)
            {
                npcController.isMoving = true;
                MoveToRandomPos();
            }
        }



        // move to the random position
        public void MoveToRandomPos()
        {
            Vector3 newPos = GetRandomPositionInTerrain();
            npcController.MoveTo(newPos);
        }


        // find a random position in terrain
        public Vector3 GetRandomPositionInTerrain()
        {
            float terrainWidth = Terrain.activeTerrain.terrainData.size.x;
            float terrainLength = Terrain.activeTerrain.terrainData.size.z;
            Vector3 terrainPos = Terrain.activeTerrain.transform.position;

            Vector3 newPos = new Vector3(
                Random.Range(terrainPos.x, terrainPos.x + terrainWidth),
                0,
                Random.Range(terrainPos.z, terrainPos.z + terrainLength)
            );

            return newPos;

        }
    }
}