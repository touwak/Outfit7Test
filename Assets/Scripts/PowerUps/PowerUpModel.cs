using UnityEngine;

namespace Outfit7.PowerUp
{
    [CreateAssetMenu(fileName = "New PowerUp", menuName = "Scriptable Objects/PowerUp")]
    public class PowerUpModel : ScriptableObject
    {
        public float Duration;
        public int EffectValue;
    }
}