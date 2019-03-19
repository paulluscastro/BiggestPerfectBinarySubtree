using System;
using System.Collections.Generic;
using System.Text;

namespace BiggestPerfectBinarySubtree.Classes
{
    public class PerfectBinaryTree
    {
        private static bool PerfectNode(BinaryTree t) => t == null || (t.Left != null && t.Right != null);
        private static int SmallestLeaf(BinaryTree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            if (t.Left != null && t.Right != null)
                return Math.Min(SmallestLeaf(t.Left, currentLevel + 1), SmallestLeaf(t.Right, currentLevel + 1));
            else if (t.Left != null)
                return SmallestLeaf(t.Left, currentLevel + 1);
            else
                return SmallestLeaf(t.Right, currentLevel + 1);
        }
        private static int HighestLeaf(BinaryTree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            return Math.Max(HighestLeaf(t.Left, currentLevel + 1), HighestLeaf(t.Right, currentLevel + 1));
        }
        private static bool DepthCheck(BinaryTree t, int maxLevel, int currentLevel)
        {
            if (currentLevel < maxLevel && !PerfectNode(t)) return false;
            if (t == null) return currentLevel != maxLevel;
            return DepthCheck(t.Left, maxLevel, currentLevel + 1) && DepthCheck(t.Right, maxLevel, currentLevel + 1);
        }
        private static int HighestPerfectSubtreeHeight(BinaryTree t, int currentLevel)
        {
            if (t == null) return 0;
            int possiblePerfectHeight = SmallestLeaf(t, currentLevel);
            while (possiblePerfectHeight > 1)
            {
                if (!DepthCheck(t, possiblePerfectHeight, 0))
                    possiblePerfectHeight--;
                else
                    break;
            }
            int higher = Math.Max(possiblePerfectHeight, HighestPerfectSubtreeHeight(t.Left, currentLevel + 1));
            higher = Math.Max(higher, HighestPerfectSubtreeHeight(t.Right, currentLevel + 1));
            return higher;
        }
        public static int HighestPerfectSubtreeHeight(BinaryTree t) => HighestPerfectSubtreeHeight(t, 0);
        public static int HighestPerfectSubtreeNodesQuantity(BinaryTree t) => (int)Math.Pow(2, HighestPerfectSubtreeHeight(t, 0)) -1;
        public static bool IsPerfect(BinaryTree tree)
        {
            int min = SmallestLeaf(tree, 0);
            int max = HighestLeaf(tree, 0);
            if (min != max) return false;
            return DepthCheck(tree, max, 0);
        }
    }
}
