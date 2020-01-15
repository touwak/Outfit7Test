using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.PowerUp
{
    public class PUShieldController : PowerUpController
    {
        private void Update()
        {
            if (Time.time > m_durationTimer)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag(this.tag))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}