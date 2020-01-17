using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Outfit7.UI.GameOver
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_score;
        [SerializeField]
        private Button m_restartBtn;

        private void OnEnable()
        {
            m_restartBtn.onClick.AddListener(() => ReloadScene());
            m_score.SetText(string.Concat("SCORE ", ReferenceVault.Instance.ScoreController.Score.ToString()));
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}