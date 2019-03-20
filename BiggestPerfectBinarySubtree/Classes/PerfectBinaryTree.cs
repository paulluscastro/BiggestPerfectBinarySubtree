using System;
using System.Collections.Generic;
using System.Text;

namespace BiggestPerfectBinarySubtree.Classes
{
    public class PerfectBinaryTree
    {
        private static bool PerfectNode(BinaryTree t) => t == null || (t.Left != null && t.Right != null);
        private static int ShallowestLeaf(BinaryTree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            if (t.Left != null && t.Right != null)
                return Math.Min(ShallowestLeaf(t.Left, currentLevel + 1), ShallowestLeaf(t.Right, currentLevel + 1));
            else if (t.Left != null)
                return ShallowestLeaf(t.Left, currentLevel + 1);
            else
                return ShallowestLeaf(t.Right, currentLevel + 1);
        }
        private static int DeepestLeaf(BinaryTree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            return Math.Max(DeepestLeaf(t.Left, currentLevel + 1), DeepestLeaf(t.Right, currentLevel + 1));
        }
        private static bool DepthCheck(BinaryTree t, int maxLevel, int currentLevel)
        {
            if (currentLevel < maxLevel && !PerfectNode(t)) return false;
            if (t == null) return currentLevel != maxLevel;
            return DepthCheck(t.Left, maxLevel, currentLevel + 1) && DepthCheck(t.Right, maxLevel, currentLevel + 1);
        }
        private static int BiggestPerfectSubtreeHeight(BinaryTree t, int currentLevel)
        {
            if (t == null) return 0;
            int currentHeight = ShallowestLeaf(t, currentLevel);
            while (currentHeight > 1)
            {
                if (!DepthCheck(t, currentHeight, 0))
                    currentHeight--;
                else
                    break;
            }
            int higher = Math.Max(currentHeight, BiggestPerfectSubtreeHeight(t.Left, currentLevel + 1));
            higher = Math.Max(higher, BiggestPerfectSubtreeHeight(t.Right, currentLevel + 1));
            return higher;
        }
        public static int BiggestPerfectSubtreeHeight(BinaryTree t) => BiggestPerfectSubtreeHeight(t, 0);
        public static int BiggestPerfectSubtreeNodes(BinaryTree t) => (int)Math.Pow(2, BiggestPerfectSubtreeHeight(t, 0)) - 1;
        public static bool IsPerfect(BinaryTree tree)
        {
            int min = ShallowestLeaf(tree, 0);
            int max = DeepestLeaf(tree, 0);
            if (min != max) return false;
            return DepthCheck(tree, max, 0);
        }
    }
}
