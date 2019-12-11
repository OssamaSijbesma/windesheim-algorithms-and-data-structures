using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex2MIBTree
{
    public class MIBTree : BinarySearchTree<MIBNode>
    {
        public MIBTree()
        {
            Insert(new MIBNode("1.3.6.1.4.1.9", "cisco"));
            Insert(new MIBNode("1.3.6.1.1.1.1", "system"));
            Insert(new MIBNode("1.3.6", "dod"));
            Insert(new MIBNode("1.3.6.1.1.1.4", "ip"));
            Insert(new MIBNode("1.3.6.1.3", "experimental"));
            Insert(new MIBNode("1.3.6.1.4.1", "enterprise"));
            Insert(new MIBNode("1.3.6.1.1.1.2", "interfaces"));
            Insert(new MIBNode("1.3.6.1.1", "directory"));
            Insert(new MIBNode("1.3", "org"));
            Insert(new MIBNode("1.3.6.1.4.1.2636", "juniperMIB"));
            Insert(new MIBNode("1.3.6.1.4.1.311", "microsoft"));
            Insert(new MIBNode("1.3.6.1", "internet"));
            Insert(new MIBNode("1", "iso"));
            Insert(new MIBNode("1.3.6.1.4", "private"));
            Insert(new MIBNode("1.3.6.1.1.1", "mib-2"));
            Insert(new MIBNode("1.3.6.1.2", "mgmt"));
        }

        public MIBNode FindNode(string oid) 
        {
            BinaryNode<MIBNode> node = Find(new MIBNode(oid, null), root);

            if (node != null) 
                return node.data;

            return null;
        }


        public bool AllNodesAvailable(string oid)
        {
            while (oid.Contains('.'))
            {
                BinaryNode<MIBNode> node = Find(new MIBNode(oid, null), root);
                if (node == null)
                    return false;

                oid = oid.Substring(0, oid.LastIndexOf('.'));
            }

            return true;
        }
    }
}
