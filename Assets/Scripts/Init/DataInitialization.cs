using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BallShooter
{
    internal sealed class DataInitialization
    {
        public static void Initialization(GameData data)
        {
            data.OriginTransform = GameObject.Find("SpawnPoint").transform;
            data.MaxBalls = 30;
            data.Score = 0;
            data.Health = 20;
            data.ActiveBalls = 0;
            data.Pool = new ObjectPool(data.Prefab, data.OriginTransform);
            data.Colliders = new Collider2D[data.MaxBalls];
            data.Balls = new Ball[data.MaxBalls];
            data.BallObjects = new GameObject[data.MaxBalls];
        }
    }
}