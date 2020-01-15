using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Obstacle
{
    public class MeteorController : ObstacleController
    {
        private void Start()
        {
            base.Start();
            m_rigidbody.velocity = Vector3.down * m_obstacleModel.Speed;
        }
    }
}