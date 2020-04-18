using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT2
{
    public class BSTArray
    {
        private const int MAX_NODES = 100;
        public BSTNode[] tree = new BSTNode[MAX_NODES];
        public int root = BSTNode.UNDEFINED;

        public BSTArray()
        {
            for (int i = 0; i < tree.Length; i++)
            {
                tree[i] = new BSTNode();
            }
        }

        public void Add(int data)
        {
            int position = -1;

            for (int i = 0; i < tree.Length; i++)
                if (tree[i].data == BSTNode.UNDEFINED)
                {
                    position = i;
                    break;
                }

            tree[position] = new BSTNode(data);

            if (root == BSTNode.UNDEFINED)
                root = position;
            else
                Insert(tree[root], data, position);
        }

        private void Insert(BSTNode node, int data, int position)
        {
            if (node.data.CompareTo(data) > 0)
                if (node.left == BSTNode.UNDEFINED)
                    node.left = position;
                else
                    Insert(tree[node.left], data, position);
            else if (node.data.CompareTo(data) < 0)
                if (node.right == BSTNode.UNDEFINED)
                    node.right = position;
                else
                    Insert(tree[node.right], data, position);
        }

        public bool Contains(int data)
        {
            if (root == BSTNode.UNDEFINED)
                return false;

            BSTNode node = Find(data, tree[root]);

            if (node == null)
                return false;

            // oude code log (n)
            //for (int i = 0; i < tree.Length; i++)
            //    if (tree[i].data == data)
            //        return true;

            return true;
        }

        public string GetPreOrder()
        {
            if (root == BSTNode.UNDEFINED)
                return "";

            return PreOrder(tree[root]);
        }

        private string PreOrder(BSTNode node)
        {
            return node.data +
                ((node.left != -1) ? $", {PreOrder(tree[node.left])}" : "") +
                ((node.right != -1) ? $" , {PreOrder(tree[node.right])}" : "");
        }

        public bool Remove(int data)
        {
            for (int i = 0; i < tree.Length; i++)
                if (tree[i].data == data)
                {
                    tree[i] = new BSTNode();

                    if (root == i)
                        root = BSTNode.UNDEFINED;

                    return true;
                }

            return false;
        }


        private BSTNode Find(int data, BSTNode node)
        {
            while (node != null)
            {
                if (node.data.CompareTo(data) > 0)
                    if (node.left == -1)
                        return null;
                    else
                        node = tree[node.left];
                else if (node.data.CompareTo(data) < 0)
                    if (node.right == -1)
                        return null;
                    else
                        node = tree[node.right];
                else
                    return node;
            }

            return null;
        }

    }
}
