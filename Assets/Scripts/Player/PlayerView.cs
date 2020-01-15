using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outfit7.PowerUp;

namespace Outfit7.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_shield;
        [SerializeField]
        private PUDamageController m_fireRateController;

        public void ActiveShield()
        {
            m_shield.SetActive(true);
        }

        public void ActivePUMoreDamage()
        {
            m_fireRateController.ActivePowerUp();
        }
       
    }
}
        

//TODO shield, HUD, etc