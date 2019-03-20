using BiggestPerfectBinarySubtree.Classes;

namespace BiggestPerfectBinarySubtree.Tests.ObjectMother
{
    public class BinaryTreeObjectMother
    {
        public static BinaryTree CreatePerfectTreeWith3Levels()
        {
            BinaryTree root = new BinaryTree(1000);  // Level 1
            root.Insert(800); // Level 2
            root.Insert(700); // Level 3
            root.Insert(900); // Level 3
            root.Insert(1200); // Level 2
            root.Insert(1100); // Level 3
            root.Insert(1300); // Level 3
            return root;
        }
        public static BinaryTree CreatePerfectTreeWith4Levels()
        {
            BinaryTree root = CreatePerfectTreeWith3Levels();
            root.Insert(650); // Level 4
            root.Insert(750); // Level 4
            root.Insert(850); // Level 4
            root.Insert(950); // Level 4
            root.Insert(1050); // Level 4
            root.Insert(1150); // Level 4
            root.Insert(1250); // Level 4
            root.Insert(1350); // Level 4
            return root;
        }
    }
}
