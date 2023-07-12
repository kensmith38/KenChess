using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenGenericNode
{
    public static class UtilitiesForNodes
    {
        
        /// <summary>
        /// Recursive method to expand the corePath repeatedly until expansion is complete.
        /// For ChessMoveNodes the corePath will be ordered such that RichText can be generated from the corePath.
        /// </summary>
        public static void ExpandCorePath(List<KenNode> corePath)
        {
            KenNode firstNodeNeedingExpansion = GetFirstNodeNeedingExpansion(corePath);
            if (firstNodeNeedingExpansion != null)
            {
                List<KenNode> nextLevelCorePath = GetCorePathAtNode(firstNodeNeedingExpansion);
                ReplaceNodeWithLevel1Expansion(firstNodeNeedingExpansion, nextLevelCorePath, corePath);
                ExpandCorePath(corePath);
            }
        }
        public static List<KenNode> GetCorePathAtNode(KenNode node)
        {
            List<KenNode> corePath = new List<KenNode>();
            corePath.Add(node);
            node.NodeNeedsExpansion = false;
            KenNode nextMainlineNode = node.ChildNodes.Count > 0 ? node.ChildNodes[0] : null;
            while (nextMainlineNode != null)
            {
                corePath.Add(nextMainlineNode);
                nextMainlineNode.NodeNeedsExpansion = false;
                if (nextMainlineNode.ParentNode.ChildNodes.Count > 1)
                {
                    for (int iii = 1; iii < nextMainlineNode.ParentNode.ChildNodes.Count; iii++)
                    {
                        KenNode childNode = nextMainlineNode.ParentNode.ChildNodes[iii];
                        corePath.Add(CreateParenthesisNode("("));
                        corePath.Add(childNode);
                        corePath.Add(CreateParenthesisNode(")"));
                        childNode.NodeNeedsExpansion = true;
                    }
                }
                nextMainlineNode = nextMainlineNode.ChildNodes.Count > 0 ? nextMainlineNode.ChildNodes[0] : null;
            }
            return corePath;
        }
        /// <summary>
        /// Called repeatedly to get to level where no more nodes need replacement
        /// </summary>
        public static void ReplaceNodeWithLevel1Expansion(KenNode nodeToReplace, List<KenNode> level1Branch, List<KenNode> currentTraversalPath)
        {
            int indexOfNodeToReplace = GetIndexOfNodeInPath(nodeToReplace, currentTraversalPath);
            currentTraversalPath.RemoveAt(indexOfNodeToReplace);
            for (int iii = 0; iii < level1Branch.Count; iii++)
            {
                currentTraversalPath.Insert(indexOfNodeToReplace++, level1Branch[iii]);
            }
            nodeToReplace.NodeNeedsExpansion = false;
        }
        /// <summary>
        /// Creates a LeftParenNode or RightParenNode based on paren = "(" or ")"
        /// </summary>
        public static KenNode CreateParenthesisNode(string parenthesisChar)
        {
            KenNode parenthesisNode = new KenNode();
            parenthesisNode.NodeID = parenthesisChar;
            parenthesisNode.NodeNeedsExpansion = false;
            return parenthesisNode;
        }

        public static KenNode GetFirstNodeNeedingExpansion(List<KenNode> listNodes)
        {
            KenNode firstNodeNeedingExpansion = null;
            foreach (KenNode nextnode in listNodes)
            {
                if (nextnode.NodeNeedsExpansion)
                {
                    firstNodeNeedingExpansion = nextnode;
                    break;
                }
            }
            return firstNodeNeedingExpansion;
        }
        public static int GetIndexOfNodeInPath(KenNode specificNode, List<KenNode> listNodes)
        {
            int indexOfNode = -1;
            for (int iii = 0; iii < listNodes.Count; iii++)
            {
                if (specificNode == listNodes[iii])
                {
                    indexOfNode = iii;
                    break;
                }
            }
            return indexOfNode;
        }
    }
}
