using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HL.Characters.NPCController
{
    public class NPCController : MonoBehaviour
    {
        public float moveSpeed;
        public bool isMoving = false;

        public BehaviorTree behaviorTree;
        public BlackBoard blackBoard;

        // Start is called before the first frame update
        void Start()
        {
            blackBoard = new BlackBoard();
            behaviorTree = new BehaviorTree(blackBoard);

            var idleNode = new IdleActionNode(this);
            behaviorTree.SetRoot(idleNode);

        }




        // Update is called once per frame
        void Update()
        {
            behaviorTree.Tick();
        }

        public void MoveTo(Vector3 newPos)
        {
            StartCoroutine(MoveToPosition(newPos));
        }

        private IEnumerator MoveToPosition(Vector3 newPos)
        {
            isMoving = true;

            while (Vector3.Distance(transform.position, newPos) > 0.1f)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            isMoving = false;
        }
    }
}