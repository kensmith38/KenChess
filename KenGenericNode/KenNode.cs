using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenGenericNode
{
    // Design: ChessMoveNode inherits from KenNode so the KenGenericNode project has all the code we need to
    //      transform GameRepresentation into a "friendlyPath" which can be used
    //      to create a RichTextBox used in the KenChess application!
    public class KenNode
    {
        // NodeID is a friendly name and is not necessarily unique.
        // Tricky! NodeID may be "(" or ")" to indicate special node
        //      that we refer to as LeftParenthesisNode / RightParenthesisNode.
        public string NodeID { get; set; }
        public bool NodeNeedsExpansion { get; set; }
        public KenNode ParentNode { get; set; }
        public List<KenNode> ChildNodes { get; set; }
        /// <summary>
        /// Default constructor called implicitly if derived class does not invoke a base class constructor explicitly
        /// </summary>
        public KenNode()
        {
            NodeNeedsExpansion = true;
            ChildNodes = new List<KenNode>();
            ParentNode = null;

        }
        /// <summary>
        /// Instantiating a node automatically sets parent/child linkages
        /// </summary>
        public KenNode(string nodeID, KenNode parentNode)
        {
            NodeID = nodeID;
            NodeNeedsExpansion = true;
            ParentNode = parentNode;
            ChildNodes = new List<KenNode>();
            if (parentNode != null)
            {
                parentNode.ChildNodes.Add(this);
            }
        }
        // Left and right parenthesis nodes define path variations (just like in Chess PGN notation)
        public bool IsLeftParenthesisNode()
        {
            return NodeID != null && NodeID.Equals("(");
        }
        public bool IsRightParenthesisNode()
        {
            return NodeID != null && NodeID.Equals(")");
        }
        public override string ToString()
        {
            return NodeID + (NodeNeedsExpansion ? "x" : "");
        }
    }
}
