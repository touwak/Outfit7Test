using Outfit7.Bullet;
using Outfit7.Interface;
using Outfit7.Spaceship;
using Outfit7.Util.Singleton;
using UnityEngine;

namespace Outfit7.Obstacle
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class ObstacleController : MonoBehaviour, IDamageable<int>, IKillable
    {
        [SerializeField]
        protected ObstacleModel m_obstacleModel;

        protected Rigidbody m_rigidbody;
        protected int m_health;
        protected float m_speed;

        protected void Start()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        protected void OnEnable()
        {
            m_health = m_obstacleModel.Health;
            m_speed = m_obstacleModel.Speed;
        }

        public void Damage(int damageTaken)
        {
            m_health -= damageTaken;

            if (m_health <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            ReferenceVault.Instance.ScoreController.SetScore(m_obstacleModel.Score);
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
            else if (other.CompareTag("Player"))
            {
                other.GetComponent<SpaceshipController>().Damage(m_obstacleModel.Damage);
                Kill();
            }
        }
    }
}