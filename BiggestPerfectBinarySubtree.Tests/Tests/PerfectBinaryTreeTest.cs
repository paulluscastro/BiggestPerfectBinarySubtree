using BiggestPerfectBinarySubtree.Classes;
using BiggestPerfectBinarySubtree.Tests.ObjectMother;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggestPerfectBinarySubtree.Tests
{
    [TestClass]
    public class PerfectBinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeWith3LevelsShouldBePerfect() => Assert.IsTrue(PerfectBinaryTree.IsPerfect(BinaryTreeObjectMother.CreatePerfectTreeWith3Levels()));
        [TestMethod]
        public void BinaryTreeWith4LevelsShouldBePerfect() => Assert.IsTrue(PerfectBinaryTree.IsPerfect(BinaryTreeObjectMother.CreatePerfectTreeWith4Levels()));
        [TestMethod]
        public void BinaryTreeWith3LevelsShouldNotBePerfect()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith3Levels();
            BinaryTree node80 = root.Find(800);
            node80.Left = null;
            Assert.IsFalse(PerfectBinaryTree.IsPerfect(root));
        }
        [TestMethod]
        public void BinaryTreeWith4LevelsShouldNotBePerfect()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith4Levels();
            BinaryTree node110 = root.Find(1100);
            node110.Right = null;
            Assert.IsFalse(PerfectBinaryTree.IsPerfect(root));
        }
        [TestMethod]
        public void PerfectBinaryTreeWith3LevelsShouldHighestPerfectSubtreeOf2() => Assert.AreEqual(2, PerfectBinaryTree.BiggestPerfectSubtreeHeight(BinaryTreeObjectMother.CreatePerfectTreeWith3Levels()));
        [TestMethod]
        public void PerfectBinaryTreeWith4LevelsShouldHighestPerfectSubtreeOf3() => Assert.AreEqual(3, PerfectBinaryTree.BiggestPerfectSubtreeHeight(BinaryTreeObjectMother.CreatePerfectTreeWith4Levels()));
        [TestMethod]
        public void ImperfectBinaryTreeWith7LevelsShouldHighestPerfectSubtreeOf4()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith4Levels();
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
            Assert.AreEqual(4, PerfectBinaryTree.BiggestPerfectSubtreeHeight(root));
        }
        public void ImperfectBinaryTreeShouldReturn7NodesOfHighestPerfectSubtree()
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
            Assert.AreEqual(7, PerfectBinaryTree.BiggestPerfectSubtreeNodes(BinaryTreeObjectMother.CreatePerfectTreeWith4Levels()));
        }
    }
}
