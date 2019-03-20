# Biggest Perfect Binary Subtree
[According to Wikipedia](https://en.wikipedia.org/wiki/Binary_tree) a Binary Tree _"is a [tree](https://en.wikipedia.org/wiki/Tree_structure "Tree structure")  [data structure](https://en.wikipedia.org/wiki/Data_structure "Data structure") in which each node has at most two [children](https://en.wikipedia.org/wiki/Child_node "Child node"), which are referred to as the *left child* and the *right child*"_

A Binary Tree is considered a [Perfect Binary Tree](https://ece.uwaterloo.ca/~cmoreno/ece250/4.05.PerfectBinaryTrees.pdf) when:
- all leaf nodes have the same depth, _h_, and
- all other nodes are full nodes.

[![Example of a Perfect Binary Tree](https://i.imgur.com/zVsHOqT.png "Example of a Perfect Binary Tree")](https://i.imgur.com/zVsHOqT.png "Example of a Perfect Binary Tree")

This project was developed to attend the challenge to detect the Biggest Perfect Binary Subtree inside a given Binary Tree.

## Challenge explanation:
**Given a Binary Tree retrieve how many nodes it's biggest Perfect Binary Subtree contains?**
[![Sample Binary Tree](https://i.imgur.com/GGL1zIC.png "Sample Binary Tree")](https://i.imgur.com/GGL1zIC.png "Sample Binary Tree")

In the example above it is possible to detect 5 Perfect Binary Subtrees:
- 8, 10, 20 (3 nodes)
- 12, 15, 16 (3 nodes)
- 25, 30, 40 (3 nodes)
- 15, 20, 30 (3 nodes)
- 12, 15, 16, 20, 25, 30, 40 (7 nodes)

So, in this example the answer would be: 7.
[![Biggest Perfect Binary Subtree in the given example](https://i.imgur.com/dsbsBbn.png "Biggest Perfect Binary Subtree in the given example")](https://i.imgur.com/dsbsBbn.png| "Biggest Perfect Binary Subtree in the given example")

## The Code
The code was developed in C#.NET and is comprised of 2 projects:
1. **A .NET Core Class Library:** which contains the classes used to solve the problem.
2. **A MS Unit Test Project:** used to test the routines developed in the first project.

The class library contains 2 classes to solve the challenge: `BinaryTree` and `PerfectBinaryTree`.

### `BinaryTree` Class
The `BinaryTree` class holds the Tree structure and methods that enable the building of the tree.

#### Properties
|Name|Description|
|--|--|
| **Left** | A reference to the left node of the tree. |
| **Right** | A reference to the right node of the tree. |
| **Value** | The value that the current node stores. |

#### Methods
|Signature|Description|
|--|--|
| **BinaryTree Insert(int)** | Inserts the value in the tree. |
| **BinaryTree Find(int)** | Finds a value in the tree. Returns the node containing the value if found, otherwise returns null. |
| **int Count()** | Counts the total number of nodes the tree holds. |

### `PerfectBinaryTree` Class
The `PerfectBinaryTree` has 3 static methods that do the analysis of Perfect Binary Trees (or Subtrees).

#### Methods
|Signature|Description|
|--|--|
| **bool IsPerfect(BinaryTree)** | Checks if a Binary Tree is perfect or not. |
| **int BiggestPerfectSubtreeHeight(BinaryTree)** | Returns the height of the biggest perfect binary subtree inside the given tree _(root node has height 0)_ |
| **int BiggestPerfectSubtreeNodes(BinaryTree)** | Returns the number of nodes of the biggest perfect binary subtree inside the given tree _(root node has height 0)_ |

## Algorithm explanation

#### Perfect Node
For the purposes of this algorithm a Perfect Node is a node that has both links, left and right, filled.

#### Perfect Binary Tree
Below follows the logic to determine if a Binary Tree is perfect:
1. Calculate the height of the Shallowest Leaf of the given tree;
2. Calculate the height of the Deepest Leaf of the given tree;
3. If the Deepest Leaf and the Shallowest Leaf have different heights, the tree is not perfect and the analysis is done. If they have the same depth the algorithm continues;
4. If all nodes of the tree are Perfect Nodes, except the leafs, then the tree is perfect;

The check of nodes is made recursively:
```cs
private static bool PerfectNode(BinaryTree t) => t == null || (t.Left != null && t.Right != null);
private static bool DepthCheck(BinaryTree t, int maxLevel, int currentLevel)
{
	if (currentLevel < maxLevel && !PerfectNode(t)) return false;
	if (t == null) return currentLevel != maxLevel;
	return DepthCheck(t.Left, maxLevel, currentLevel + 1) && DepthCheck(t.Right, maxLevel, currentLevel + 1);
}
public static bool IsPerfect(BinaryTree tree)
{
	int min = ShallowestLeaf(tree, 0);
	int max = DeepestLeaf(tree, 0);
	if (min != max) return false;
	return DepthCheck(tree, max, 0);
}
```
#### Biggest Perfect Binary Tree
Given a tree the algorithm calculates the biggest subtree by checking the current tree and its left and right subtrees, returning the biggest of these 3 trees.

1. Calculate the height of the Shallowest Leaf;
2. Starting from the current node do a Depth Check with the Shallowest Leaf as the maximum depth to be analyzed  as that will be the maximum height of a possible subtree;
3. If the current height is a Perfect Binary Tree then return the current height as the value, otherwise subtract 1 level and recheck it. Do that while the maximum level is higher than 1;
4. Holding current maximum Perfect Subtree, recursively check the size of the maximum left and right Perfect Subtrees. Return the highest of these 3;
```cs
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
```
## Tools and Bibliography
This solution was made with:
- **Microsoft [Visual Studio](https://visualstudio.microsoft.com "Visual Studio") Enterprise 2019 RC (Preview 4.3)**
- **Joel Martin's [Binary Tree Visualization](https://kanaka.github.io/rbt_cfs/trees.html "Binary Tree Visualization")** _(used to create the images of the sample Binary Trees)_
- **Pandao's [Editor.md](https://pandao.github.io/editor.md/en.html "MD Editor")** _(used to write this README.md file)_
- ** [Douglas Wilhelm Harder](https://github.com/dwharder "Douglas Wilhelm Harder")'s [explanations of Perfect Binary Trees](https://ece.uwaterloo.ca/~cmoreno/ece250/4.05.PerfectBinaryTrees.pdf "explanations of Perfect Binary Trees")**