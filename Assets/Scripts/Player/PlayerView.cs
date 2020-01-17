using Outfit7.PowerUp;
using Outfit7.Spaceship;
using UnityEngine;
using UnityEngine.UI;

namespace Outfit7.Player
{
    public class PlayerView : SpaceshipView
    {
        [SerializeField]
        private GameObject m_shield;
        [SerializeField]
        private PUDamageController m_fireRateController;
        [SerializeField]
        private Slider m_HealthSlider;

        public void ActiveShield()
        {
            m_shield.SetActive(true);
        }

        public void ActivePUMoreDamage()
        {
            m_fireRateController.ActivePowerUp();
        }

        public void SetHealthSlider(float value)
        {
            m_HealthSlider.value = value;
        }
    }
}