# Biggest Perfect Binary Subtree

[According to Wikipedia](https://en.wikipedia.org/wiki/Binary_tree) a Binary Tree _"is a [tree](https://en.wikipedia.org/wiki/Tree_structure "Tree structure")  [data structure](https://en.wikipedia.org/wiki/Data_structure "Data structure") in which each node has at most two [children](https://en.wikipedia.org/wiki/Child_node "Child node"), which are referred to as the *left child* and the *right child*"_

A Binary Tree is considered a [Perfect Binary Tree](https://ece.uwaterloo.ca/~cmoreno/ece250/4.05.PerfectBinaryTrees.pdf) when:
- all leaf nodes have the same depth, _h_, and
- all other nodes are full nodes.

This project is comprised of  a .NET Core Class Library and a MS Unit Test (.NET Core) Project. The Class Library contains 2 classes: `BinaryTree` and `PerfectBinaryTree`.

## Binary Tree
The `BinaryTree` holds the Tree structure and methods that enable the building of the tree.

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