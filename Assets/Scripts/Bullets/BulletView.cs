using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField]
        private Material m_material;

        public void SetBulletColour(Color colour)
        {
            m_material.color = colour;
        }
    }
}
