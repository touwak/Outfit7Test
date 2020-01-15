using TMPro;
using UnityEngine;

namespace Outfit7.UI.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_tmpScore;

        public void SetScore(int value)
        {
            m_tmpScore.SetText(value.ToString());
        }
    }
}