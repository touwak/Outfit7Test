using UnityEngine;

namespace Outfit7.Bullet
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Scriptable Objects/Bullet")]
    public class BulletModel : ScriptableObject
    {
        public int Damage;
        public int Modifier;
        public int Speed;
        public Color Colour;
    }
}