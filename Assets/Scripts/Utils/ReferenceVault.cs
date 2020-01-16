using Outfit7.UI.Score;
using System;
using UnityEngine;
using Outfit7.Manager.GameManager;

public class ReferenceVault : MonoBehaviour
{
    public ScoreController ScoreController => m_scoreController;
    public GameManager GameManager => m_gameManager;
    public static ReferenceVault Instance => s_instance;

    [SerializeField]
    private ScoreController m_scoreController;
    [SerializeField]
    private GameManager m_gameManager;

    private static ReferenceVault s_instance = null;

    private void Awake()
    {
        s_instance = this;
    }
}