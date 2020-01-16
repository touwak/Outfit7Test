using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfit7.Manager.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public bool GamePaused => m_gamePaused;

        [SerializeField]
        private GameObject m_InGameMenu;
        [SerializeField]
        private GameObject m_gameOverMenu;

        private bool m_gamePaused = false;

        public void ShowGameOverMenu(bool show)
        {
            m_InGameMenu.SetActive(!show);
            m_gameOverMenu.SetActive(show);
            m_gamePaused = show;
        }
    }
}
