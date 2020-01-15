using Outfit7.Bullet;
using UnityEngine;

namespace Outfit7.PowerUp
{
    public class PUDamageController : PowerUpController
    {
        [SerializeField]
        private BulletModel m_bulletModel;
        private bool inUse = false;
        private float m_playerFireRate;

        private void Update()
        {
            if (inUse)
            {
                if (Time.time > m_durationTimer)
                {
                    DeActivePowerUp();
                }
            }
        }

        public void ActivePowerUp()
        {
            ResetTimer();
            inUse = true;

            m_bulletModel.Modifier = m_powerUpModel.EffectValue;
        }

        private void DeActivePowerUp()
        {
            inUse = false;
            m_bulletModel.Modifier = 0;
        }

        private void OnDestroy()
        {
            if(m_bulletModel != null)
                m_bulletModel.Modifier = 0;
        }
    }
}