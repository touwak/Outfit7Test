using UnityEngine;

namespace Outfit7.Obstacle
{
    [CreateAssetMenu(fileName = "New Obstacle", menuName = "Scriptable Objects/Obstacle")]
    public class ObstacleModel : ScriptableObject
    {
        public int Health;
        public float Speed;
        public int Damage;
        public int Score;
    }
}