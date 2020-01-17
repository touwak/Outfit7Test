using Outfit7.Interface;
using UnityEngine;

namespace Outfit7.PowerUp
{
    [RequireComponent(typeof(Rigidbody))]
    public class PowerUpItem : MonoBehaviour, IPowerUp
    {
        [SerializeField]
        private Rigidbody m_rigidbody;

        private float m_speed = 2;

        private void Start()
        {
            m_rigidbody.velocity = Vector3.down * m_speed;
        }
    }
}