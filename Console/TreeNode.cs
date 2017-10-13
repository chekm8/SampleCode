using System.Collections.Generic;

namespace CodeSample
{
    internal class TreeNode
    {
        private string _value;

        internal TreeNode()
        {
            Value = string.Empty;
            SubNodes = new List<TreeNode>();
        }

        internal TreeNode Parent;
        internal List<TreeNode> SubNodes;
        internal string Value
        {
            get => _value.Trim();
            set => _value = value;
        }

        public override string ToString()
        {
            //makes it easier to read in the debugger :)
            return Value;
        }
    }
}