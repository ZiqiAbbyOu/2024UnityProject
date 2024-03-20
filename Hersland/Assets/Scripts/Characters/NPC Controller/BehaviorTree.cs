using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HL.Characters.NPCController
{
    public class BehaviorTree
    {
        private TreeNode root;
        public BlackBoard blackBoard;

        public BehaviorTree(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public void SetRoot(TreeNode node)
        {
            this.root = node;
        }

        public void Tick()
        {
            root.Evaluate();
        }
    }
}