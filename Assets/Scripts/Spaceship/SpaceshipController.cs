using Outfit7.Interface;
using UnityEngine;
using Outfit7.Bullet;

namespace Outfit7.Spaceship
{
    [RequireComponent(typeof(BoxCollider))]
    public class SpaceshipController : MonoBehaviour, IDamageable<int>, IKillable
    {
        [SerializeField]
        protected SpaceshipModel m_spaceshipModel;

        protected int m_health;
        protected int m_lives;
        protected float m_fireRate;

        protected void OnEnable()
        {
            m_health = m_spaceshipModel.Health;
            m_lives = m_spaceshipModel.Lives;
            m_fireRate = m_spaceshipModel.FireRate;
        }
    
        public void Damage(int damageTaken)
        {
            m_health -= damageTaken;

            if (m_health <= 0)
            {
                if (m_lives > 0)
                {
                    m_lives--;
                    m_health = m_spaceshipModel.Health;
                }
                else
                {
                    Kill();
                }
            }
        }

        public void Kill()
        {
            ReferenceVault.Instance.ScoreController.SetScore(m_spaceshipModel.Score);
            gameObject.SetActive(false);
        }

        protected void OnTriggerEnter(Collider other)
        {
            BulletController bulletController = other.GetComponent<BulletController>();
            if (bulletController != null && !bulletController.CompareTag(this.tag))
            {
                Damage(bulletController.Damage);
                other.gameObject.SetActive(false);
            }
        }

    }
}