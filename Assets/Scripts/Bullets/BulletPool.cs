using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outfit7.Util.PoolObject;

namespace Outfit7.Bullet
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_playerBulletPrefab;
        [SerializeField]
        private GameObject m_enemyBulletPrefab;

        private PoolObjectController m_playerBulletPool;
        private PoolObjectController m_enemyBulletPool;
        private const uint k_poolSize = 10;

        private void Awake()
        {
            m_playerBulletPool = new PoolObjectController(m_playerBulletPrefab, this.transform, k_poolSize);
            m_enemyBulletPool = new PoolObjectController(m_enemyBulletPrefab, this.transform, k_poolSize);
        }

        public BulletController GetPlayerBullet()
        {
            GameObject bullet = m_playerBulletPool.GetObject();
            return bullet?.GetComponent<BulletController>();
        }

        public BulletController GetEnemyBullet()
        {
            GameObject bullet = m_enemyBulletPool.GetObject();
            return bullet?.GetComponent<BulletController>();
        }
    }
}
