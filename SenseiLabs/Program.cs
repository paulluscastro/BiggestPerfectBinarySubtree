using System;
using System.Linq;

namespace SenseiLabs
{
    class Program
    {
        public class Tree
        {
            public Tree r;
            public Tree l;
            int x;
            public Tree(int x) => this.x = x;
            public void Insert(int value)
            {
                if (value < x)
                {
                    if (l != null)
                        l.Insert(value);
                    else
                        l = new Tree(value);
                } else {
                    if (r != null)
                        r.Insert(value);
                    else
                        r = new Tree(value);
                }
            }
        }
        private static bool PerfectNode(Tree t) => t.l != null && t.r != null;
        private static int SmallestLeaf(Tree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            if (t.l != null && t.r != null)
                return Math.Min(SmallestLeaf(t.l, currentLevel + 1), SmallestLeaf(t.r, currentLevel + 1));
            else if (t.l != null)
                return SmallestLeaf(t.l, currentLevel + 1);
            else
                return SmallestLeaf(t.r, currentLevel + 1);
        }
        private static int HighestLeaf(Tree t, int currentLevel)
        {
            if (t == null) return currentLevel - 1;
            return Math.Max(HighestLeaf(t.l, currentLevel + 1), HighestLeaf(t.r, currentLevel + 1));
        }
        private static bool DepthCheck(Tree t, int maxLevel, int currentLevel)
        {
            if (currentLevel < maxLevel && !PerfectNode(t)) return false;
            return DepthCheck(t.l, maxLevel, currentLevel + 1) && DepthCheck(t.r, maxLevel, currentLevel + 1);
        }
        private static int HighestPerfectSubtree(Tree t, int currentMax, int currentLevel)
        {
            if (t == null) return 0;
            int min = SmallestLeaf(t, currentLevel);
            int max = HighestLeaf(t, currentLevel);
            while (min > 1)
            {
                if (!DepthCheck(t, min, currentLevel))
                    min--;
                else
                    break;
            }
            int higher = Math.Max((int)Math.Pow(2, min + 1) - 1, HighestPerfectSubtree(t.l, currentMax, 0));
            higher = Math.Max(higher, HighestPerfectSubtree(t.r, currentMax, 0));
            return higher;
        }
        public static int solution(Tree T)
        {
            return HighestPerfectSubtree(T, 1, 0);
        }
        static void Main(string[] args)
        {
            Tree root = new Tree(10);
            root.Insert(8);
            root.Insert(9);
            root.Insert(20);
            root.Insert(15);
            root.Insert(12);
            root.Insert(16);
            root.Insert(30);
            root.Insert(25);
            root.Insert(40);
            root.Insert(35);
            Console.WriteLine("Smallest leaf: " + solution(root));
        }
    }
}
