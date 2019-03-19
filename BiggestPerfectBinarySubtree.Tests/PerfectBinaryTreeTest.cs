using BiggestPerfectBinarySubtree.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggestPerfectBinarySubtree.Tests
{
    [TestClass]
    public class PerfectBinaryTreeTest
    {
        private BinaryTree CreatePerfectTreeWith3Levels()
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
        private BinaryTree CreatePerfectTreeWith4Levels()
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

        [TestMethod]
        public void BinaryTreeWith3LevelsShouldBePerfect() => Assert.IsTrue(PerfectBinaryTree.IsPerfect(CreatePerfectTreeWith3Levels()));
        [TestMethod]
        public void BinaryTreeWith4LevelsShouldBePerfect() => Assert.IsTrue(PerfectBinaryTree.IsPerfect(CreatePerfectTreeWith4Levels()));
        [TestMethod]
        public void BinaryTreeWith3LevelsShouldNotBePerfect()
        {
            BinaryTree root = CreatePerfectTreeWith3Levels();
            BinaryTree node80 = root.Find(800);
            node80.Left = null;
            Assert.IsFalse(PerfectBinaryTree.IsPerfect(root));
        }
        [TestMethod]
        public void BinaryTreeWith4LevelsShouldNotBePerfect()
        {
            BinaryTree root = CreatePerfectTreeWith4Levels();
            BinaryTree node110 = root.Find(1100);
            node110.Right = null;
            Assert.IsFalse(PerfectBinaryTree.IsPerfect(root));
        }
        [TestMethod]
        public void PerfectBinaryTreeWith3LevelsShouldHighestPerfectSubtreeOf2() => Assert.AreEqual(2, PerfectBinaryTree.HighestPerfectSubtreeHeight(CreatePerfectTreeWith3Levels()));
        [TestMethod]
        public void PerfectBinaryTreeWith4LevelsShouldHighestPerfectSubtreeOf3() => Assert.AreEqual(3, PerfectBinaryTree.HighestPerfectSubtreeHeight(CreatePerfectTreeWith4Levels()));
        [TestMethod]
        public void ImperfectBinaryTreeWith7LevelsShouldHighestPerfectSubtreeOf4()
        {
            BinaryTree root = CreatePerfectTreeWith4Levels();
            root.Insert(500); // Level 5
            root.Insert(450); // Level 6
            root.Insert(440); // Level 7
            root.Insert(455); // Level 7
            root.Insert(550); // Level 6
            root.Insert(520); // Level 7
            root.Insert(555); // Level 7
            root.Insert(660); // Level 5
            root.Insert(655); // Level 6
            root.Insert(652); // Level 7
            root.Insert(657); // Level 7
            root.Insert(665); // Level 6
            root.Insert(662); // Level 7
            root.Insert(667); // Level 7
            root.Insert(730); // Level 5
            root.Insert(720); // Level 6
            root.Insert(715); // Level 7
            root.Insert(725); // Level 7
            root.Insert(735); // Level 6
            root.Insert(736); // Level 7
            root.Insert(734); // Level 7
            root.Insert(780); // Level 5
            root.Insert(770); // Level 6
            root.Insert(765); // Level 7
            root.Insert(775); // Level 7
            root.Insert(795); // Level 6
            root.Insert(794); // Level 7
            root.Insert(796); // Level 7
            Assert.AreEqual(4, PerfectBinaryTree.HighestPerfectSubtreeHeight(root));
        }
        public void ImperfectBinaryTreeShould7NodesOfHighestPerfectSubtree()
        {
            BinaryTree root = new BinaryTree(10);
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
            Assert.AreEqual(7, PerfectBinaryTree.HighestPerfectSubtreeNodesQuantity(CreatePerfectTreeWith4Levels()));
        }
    }
}
