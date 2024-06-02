using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG3B_2023
{
    public class random1 { 
    public static List<Node> GetRandomNodes(Node root)
    {
        List<Node> randomNodes = new List<Node>();
        Random random = new Random();

        // Helper function to perform a random traversal of the tree
        void RandomTraverse(Node node, int remainingNodes)
        {
            if (node == null || remainingNodes == 0)
                return;

           
            if (random.Next(remainingNodes) == 0)
            {
                randomNodes.Add(node);
                remainingNodes--;
            }

            // Recursively traverse the left and right subtrees
            RandomTraverse(node.Left, remainingNodes);
            RandomTraverse(node.Right, remainingNodes);
        }

        // Start the random traversal from the root with 4 remaining nodes to select
        RandomTraverse(root, 4);

        return randomNodes;
    }
   }
}
