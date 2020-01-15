using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outfit7.Util.PoolObject;

namespace Outfit7.Manager
{
    public class SpawnManager : MonoBehaviour
    {
        public int PowerUpRate => m_powerUpRate;

        [SerializeField]
        private Transform[] m_spawnPoints;
        [SerializeField]
        private Transform[] m_bgSpawnPoints;
        [SerializeField]
        private Transform[] m_parents;

        [Header("Spawned Items")]
        [SerializeField]
        private GameObject[] m_enemyPrefabs;
        [SerializeField]
        private GameObject[] m_obstaclePrefabs;
        [SerializeField]
        private GameObject[] m_powerUpPrefabs;
        [SerializeField]
        private GameObject[] m_enviromentPrefabs;

        private List<PoolObjectController> m_enemyPool;
        private List<PoolObjectController> m_obstaclePool;
        private List<PoolObjectController> m_powerUpPool;
        private List<PoolObjectController> m_enviromentPool;
        private float m_nextEnemy;
        private float m_nextObstacle;
        private float m_nextEnviroment;
        private float m_enemySpawnRate = 3f;
        private float m_obstacleSpawnRate = 6f;
        private int m_powerUpRate = 20;
        private float m_enviromentRate = 5f;
        private int m_spawnPointIndex = 0;
        private int m_objectTypeIndex = 0;

        private void Awake()
        {
            InitPools();
        }

        private void Update()
        {
            CheckSpawn();
        }

        private void InitPools()
        {
            InitPool(ref m_enemyPool, m_enemyPrefabs, m_parents[0]);
            InitPool(ref m_obstaclePool, m_obstaclePrefabs, m_parents[1]);
            InitPool(ref m_powerUpPool, m_powerUpPrefabs, m_parents[2]);
            InitPool(ref m_enviromentPool, m_enviromentPrefabs, m_parents[3]);
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

            if (Time.time > m_nextEnviroment)
                SpawnEnviroment();
        }

        private void SpawnObject(List<PoolObjectController> pool, bool useFrontSpawnPoints = true)
        {
            m_spawnPointIndex = useFrontSpawnPoints ? Random.Range(0, m_spawnPoints.Length) : Random.Range(0, m_bgSpawnPoints.Length);
            m_objectTypeIndex = Random.Range(0, pool.Count);
            GameObject toSpawn = pool[m_objectTypeIndex].GetObject();
            
            if (toSpawn)
                toSpawn.transform.position = useFrontSpawnPoints ? m_spawnPoints[m_spawnPointIndex].position : m_bgSpawnPoints[m_spawnPointIndex].position;
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

        private void SpawnEnviroment()
        {
            m_nextEnviroment = Time.time + m_enviromentRate;
            SpawnObject(m_enviromentPool, false);
        }

    }
}
