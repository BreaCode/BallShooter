using UnityEngine;

namespace BallShooter
{
    [CreateAssetMenu(fileName = "Data", menuName = "Create data")]
    internal sealed class GameData : ScriptableObject
    {
        public Transform OriginTransform;
        public ObjectPool Pool;
        public GameObject Prefab;
        public ParticleSystem Effect;
        public Collider2D[] Colliders;
        public GameObject[] BallObjects;
        public Ball[] Balls;
        public int ActiveBalls;
        public int MaxBalls;
        public int Score;
        public int Health;
    }
}

