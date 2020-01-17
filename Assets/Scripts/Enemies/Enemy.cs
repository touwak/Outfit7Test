using Outfit7.Bullet;
using Outfit7.Interface;
using Outfit7.Spaceship;
using UnityEngine;

namespace Outfit7.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : SpaceshipController, IShootable
    {
        [SerializeField]
        private Transform m_bulletsParent;
        [SerializeField]
        protected Rigidbody m_rigidbody;

        protected float m_nextFire = 1;
        private BulletPool m_bulletPool;

        protected void Start()
        {
            m_bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));
        }

        protected void Update()
        {
            if (Time.time > m_nextFire)
            {
                Fire(m_bulletPool.GetEnemyBullet());
            }
        }

        protected void OnEnable()
        {
            base.OnEnable();
        }

        public void Fire(BulletController bullet)
        {
            m_spaceshipView.PlayShootSound();
            m_nextFire = Time.time + m_spaceshipModel.FireRate;

            bullet.transform.position = m_bulletsParent.position;
            bullet.transform.rotation = m_bulletsParent.rotation;
            bullet.Rigidbody.velocity = Vector3.down * bullet.Speed;
        }
    }
}
