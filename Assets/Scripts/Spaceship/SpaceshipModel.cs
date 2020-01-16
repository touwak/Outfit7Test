using UnityEngine;

namespace Outfit7.Spaceship
{
    [CreateAssetMenu(fileName = "New Spaceship", menuName = "Scriptable Objects/Spaceship")]
    public class SpaceshipModel : ScriptableObject
    {
        public float Health;
        public int Lives;
        public float FireRate;
        public float Speed;
        public int Score;
    }   
}
