using Outfit7.UI.Score;
using System;
using UnityEngine;

namespace Outfit7.Util.Singleton
{
    public class ReferenceVault : MonoBehaviour
    {
        public ScoreController ScoreController => m_scoreController;
        public static ReferenceVault Instance => s_instance;

        [SerializeField]
        private ScoreController m_scoreController;
        private static ReferenceVault s_instance = null;

        private void Awake()
        {
            s_instance = this;
        }
    }
}