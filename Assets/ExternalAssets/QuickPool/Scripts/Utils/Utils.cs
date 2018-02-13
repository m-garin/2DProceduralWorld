using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Linq;

namespace QuickPool
{
    public static class Utils
    {
        public static GameObject CreateRoot(string name)
        {
            var poolsRoot = GameObject.Find("Instances");

            if (poolsRoot == null)
                poolsRoot = new GameObject("Instances");

            var root = new GameObject(name + "_Root");
            root.transform.SetParent(poolsRoot.transform);
            return root;

        }
    }

}