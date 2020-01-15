using Outfit7.Interface;
using UnityEngine;

namespace Outfit7.Bullet
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class BulletController : MonoBehaviour, IShootable
    {
        public int Damage => m_bulletModel.Damage + m_bulletModel.Modifier;
        public int Speed => m_bulletModel.Speed;
        public Rigidbody Rigidbody => m_rigidbody;

        [SerializeField]
        private BulletView m_bulletView;
        [SerializeField]
        private BulletModel m_bulletModel;

        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_bulletView.SetBulletColour(m_bulletModel.Colour);
        }
    }
}
