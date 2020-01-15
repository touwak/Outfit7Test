using UnityEngine;
using Outfit7.Manager;

namespace Outfit7.UI.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private ScoreView m_scoreView;
        [SerializeField]
        private SpawnManager m_spawnManager;

        private ScoreModel m_scoreModel;

        public void Start()
        {
            m_scoreModel = new ScoreModel();
            m_scoreModel.Score = 0;
        }

        public void SetScore(int value)
        {
            m_scoreModel.Score += value;
            m_scoreView.SetScore(m_scoreModel.Score);

            if (m_scoreModel.Score % m_spawnManager.PowerUpRate == 0)
            {
                m_spawnManager.SpawnPowerUp();
            }
        }
    }
}