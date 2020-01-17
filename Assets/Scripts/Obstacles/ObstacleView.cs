using UnityEngine;

namespace Outfit7.Obstacle
{
    [RequireComponent(typeof(AudioSource))]
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField]
        protected AudioSource m_audioSource;
        [SerializeField]
        protected AudioClip m_explosionSound;

        public void PlayExplosionSound()
        {
            m_audioSource.Play();
        }
    }
}
