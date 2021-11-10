using System.Collections;
using UnityEngine;

namespace BallShooter 
{
    internal sealed class SpawnerController : MonoBehaviour, IController, IFixed
    {
        private GameData _data;
        private ObjectPool _pool;
        private int _poolSize;
        private GameObject _prefab;
        private Ball[] _balls;
        private GameObject[] _ballObjects;
        private Collider2D[] _colliders;

        public SpawnerController(GameData data)
        {
            _data = data;
            _poolSize = data.MaxBalls;
            _balls = data.Balls;
            _prefab = data.Prefab;
            _ballObjects = data.BallObjects;
            _colliders = data.Colliders;
            _pool = data.Pool;

            for (int i = 0; i < _poolSize; i++)
            {
                _balls[i] = new Ball();
                data.BallObjects[i] = _pool.Pop();
                data.Colliders[i] = data.BallObjects[i].GetComponent<Collider2D>();
                _pool.Push(data.BallObjects[i]);
            }

            data.ActiveBalls = 0;
        }

        public void Fixed(float deltaTime)
        {
            if (_data.ActiveBalls < 30)
            {
                CreateBall();
                _data.ActiveBalls++;
            }
        }

        private void CreateBall()
        {
            int i = _data.ActiveBalls;
            _balls[i] = new Ball();
            _ballObjects[i] = _pool.Pop();
            _ballObjects[i].transform.position = _balls[i].StartPos;
            _ballObjects[i].GetComponent<SpriteRenderer>().color = _balls[i].Color;
            _ballObjects[i].transform.localScale = new Vector3(_balls[i].Scale, _balls[i].Scale, 0);
        }

    }
}

