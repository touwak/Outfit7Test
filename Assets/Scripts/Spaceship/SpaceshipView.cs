using UnityEngine;

namespace Outfit7.Spaceship
{
    [RequireComponent(typeof(AudioSource))]
    public class SpaceshipView : MonoBehaviour
    {
        [SerializeField]
        protected AudioSource m_audioSource;
        [SerializeField]
        protected AudioClip m_shootSound;
        [SerializeField]
        protected AudioClip m_explosionSound;

        public void PlayShootSound()
        {
            m_audioSource.clip = m_shootSound;
            m_audioSource.Play();
        }

        public void PlayExplosionSound()
        {
            m_audioSource.clip = m_explosionSound;
            m_audioSource.Play();
        }
    }
}