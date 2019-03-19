using System;
using System.Collections.Generic;
using System.Text;

namespace BiggestPerfectBinarySubtree.Classes
{
    public class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public int Value { get; set; }
        public BinaryTree(int value) => Value = value;
        public BinaryTree Find(int val)
        {
            if (val < Value)
                return Left?.Find(val) ?? null;
            else if (val > Value)
                return Right?.Find(val) ?? null;
            else
                return this;
        }
        public BinaryTree Insert(int val)
        {
            if (val < Value)
                return Left == null ? Left = new BinaryTree(val) : Left.Insert(val);
            else
                return Right == null ? Right = new BinaryTree(val) : Right.Insert(val);
        }
    }
}
