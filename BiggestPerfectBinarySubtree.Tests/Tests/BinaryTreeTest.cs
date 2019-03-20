using BiggestPerfectBinarySubtree.Classes;
using BiggestPerfectBinarySubtree.Tests.ObjectMother;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiggestPerfectBinarySubtree.Tests
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeShouldBeCreatedWithValue1000()
        {
            BinaryTree root = new BinaryTree(1000);
            Assert.AreEqual(1000, root.Value);
        }
        [TestMethod]
        public void BinaryTreeShouldInsertValue500AtLeft()
        {
            BinaryTree root = new BinaryTree(1000);
            root.Insert(500);
            Assert.AreEqual(500, root.Left.Value);
        }
        [TestMethod]
        public void BinaryTreeShouldInsertValue5000AtRight()
        {
            BinaryTree root = new BinaryTree(1000);
            root.Insert(5000);
            Assert.AreEqual(5000, root.Right.Value);
        }
        [TestMethod]
        public void BinaryTreeShouldFindNodes()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith3Levels();
            Assert.IsNotNull(root.Find(1000));
            Assert.IsNotNull(root.Find(800));
            Assert.IsNotNull(root.Find(700));
            Assert.IsNotNull(root.Find(900));
            Assert.IsNotNull(root.Find(1100));
            Assert.IsNotNull(root.Find(1200));
            Assert.IsNotNull(root.Find(1300));
        }
        [TestMethod]
        public void BinaryTreeShouldNotFindNodes()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith3Levels();
            Assert.IsNull(root.Find(987));
            Assert.IsNull(root.Find(28));
            Assert.IsNull(root.Find(77));
            Assert.IsNull(root.Find(98));
            Assert.IsNull(root.Find(287));
            Assert.IsNull(root.Find(932));
            Assert.IsNull(root.Find(1));
        }
        [TestMethod]
        public void BinaryTreeCountShouldReturn7Nodes()
        {
            BinaryTree root = BinaryTreeObjectMother.CreatePerfectTreeWith3Levels();
            Assert.AreEqual(7, root.Count());
        }
    }
}
