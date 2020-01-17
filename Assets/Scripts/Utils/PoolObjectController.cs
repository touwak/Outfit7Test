using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Util.PoolObject
{
    public class PoolObjectController : MonoBehaviour
    {
        public GameObject Prefab => m_poolObjectModel.Prefab;
        public List<GameObject> Pool => m_poolObjectModel.Pool;

        private PoolObjectModel m_poolObjectModel;

        public PoolObjectController(GameObject prefab, Transform parent, uint initSize = 10, bool isResizeable = true)
        {
            m_poolObjectModel = new PoolObjectModel();

            m_poolObjectModel.Pool = new List<GameObject>();
            m_poolObjectModel.Parent = parent;
            m_poolObjectModel.Resizeable = isResizeable;
            m_poolObjectModel.Prefab = prefab;
            m_poolObjectModel.ChunkSize = initSize;

            Resize();
        }

        public GameObject GetObject()
        {
            foreach (GameObject item in m_poolObjectModel.Pool)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);

                    return item;
                }
            }

            if (m_poolObjectModel.Resizeable)
            {
                Resize();
            }

            return null;
        }

        private void Resize()
        {
            for (int i = 0; i < m_poolObjectModel.ChunkSize; i++)
            {
                GameObject toInstantiate = Instantiate(m_poolObjectModel.Prefab, m_poolObjectModel.Parent.position, m_poolObjectModel.Parent.rotation, m_poolObjectModel.Parent);
                toInstantiate.SetActive(false);

                m_poolObjectModel.Pool.Add(toInstantiate);
            }
        }
    }
}