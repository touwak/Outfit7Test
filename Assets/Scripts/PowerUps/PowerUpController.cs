using UnityEngine;

namespace Outfit7.PowerUp
{
    public class PowerUpController : MonoBehaviour
    {
        public float Duration => m_powerUpModel.Duration;
        public int EffectValue => m_powerUpModel.EffectValue;

        [SerializeField]
        protected PowerUpModel m_powerUpModel;

        protected float m_durationTimer = 0;

        protected void OnEnable()
        {
            ResetTimer();
        }

        protected void ResetTimer()
        {
            m_durationTimer = Time.time + m_powerUpModel.Duration;
        }
    }
}