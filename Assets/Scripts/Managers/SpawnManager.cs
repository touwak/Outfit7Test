﻿using Outfit7.Util.PoolObject;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Manager
{
    public class SpawnManager : MonoBehaviour
    {
        public int PowerUpRate => m_powerUpRate;

        [SerializeField]
        private Transform[] m_spawnPoints;
        [SerializeField]
        private Transform[] m_pathPoints;
        [SerializeField]
        private Transform[] m_parents;

        [Header("Spawned Items")]
        [SerializeField]
        private GameObject[] m_enemyPrefabs;
        [SerializeField]
        private GameObject[] m_obstaclePrefabs;
        [SerializeField]
        private GameObject[] m_powerUpPrefabs;

        private List<PoolObjectController> m_enemyPool;
        private List<PoolObjectController> m_obstaclePool;
        private List<PoolObjectController> m_powerUpPool;
        private float m_nextEnemy;
        private float m_nextObstacle;
        private float m_enemySpawnRate = 3f;
        private float m_obstacleSpawnRate = 6f;
        private int m_powerUpRate = 20;
        private int m_spawnPointIndex = 0;
        private int m_objectTypeIndex = 0;

        private void Awake()
        {
            InitPools();
        }

        private void Update()
        {
            if (!ReferenceVault.Instance.GameManager.GamePaused)
            {
                CheckSpawn();
            }
        }

        private void InitPools()
        {
            InitEnemyPool();
            InitPool(ref m_obstaclePool, m_obstaclePrefabs, m_parents[1]);
            InitPool(ref m_powerUpPool, m_powerUpPrefabs, m_parents[2]);
        }

        private void InitPool(ref List<PoolObjectController> pool, GameObject[] prefabs, Transform parent, uint size = 5, bool resizeable = false)
        {
            if (prefabs.Length == 0) return;

            pool = new List<PoolObjectController>();

            for (int i = 0; i < prefabs.Length; i++)
            {
                pool.Add(new PoolObjectController(prefabs[i], parent, size, resizeable));
            }
        }

        private void CheckSpawn()
        {
            if (Time.time > m_nextEnemy)
                SpawnEnemy();

            if (Time.time > m_nextObstacle)
                SpawnObstacle();
        }

        private void SpawnObject(List<PoolObjectController> pool)
        {
            m_spawnPointIndex = Random.Range(0, m_spawnPoints.Length);
            m_objectTypeIndex = Random.Range(0, pool.Count);
            GameObject toSpawn = pool[m_objectTypeIndex].GetObject();

            if (toSpawn)
                toSpawn.transform.position = m_spawnPoints[m_spawnPointIndex].position;
        }

        private void InitEnemyPool()
        {
            InitPool(ref m_enemyPool, m_enemyPrefabs, m_parents[0]);

            // Set path enemies
            foreach (PoolObjectController pool in m_enemyPool)
            {
                if (pool.Prefab.GetComponent<Enemy.EnemyPath>())
                {
                    foreach (GameObject enemy in pool.Pool)
                    {
                        enemy.GetComponent<Enemy.EnemyPath>().SetPositions(m_pathPoints);
                    }

                    return;
                }
            }
        }

        private void SpawnEnemy()
        {
            m_nextEnemy = Time.time + m_enemySpawnRate;

            SpawnObject(m_enemyPool);
        }

        private void SpawnObstacle()
        {
            m_nextObstacle = Time.time + m_obstacleSpawnRate;
            SpawnObject(m_obstaclePool);
        }

        public void SpawnPowerUp()
        {
            SpawnObject(m_powerUpPool);
        }
    }
}
