using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Util.PoolObject
{
    public class PoolObjectModel
    {
        public List<GameObject> Pool;
        public bool Resizeable;
        public GameObject Prefab;
        public uint ChunkSize;
        public Transform Parent;
    }
}
