using UnityEngine;

namespace Outfit7.Enemy
{
    public class EnemyLine : Enemy
    {
        private void Start()
        {
            base.Start();
            m_rigidbody.velocity = Vector3.down * m_spaceshipModel.Speed;
        }
    }
}