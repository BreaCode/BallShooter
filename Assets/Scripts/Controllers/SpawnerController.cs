using System.Collections;
using UnityEngine;

namespace BallShooter 
{
    internal sealed class SpawnerController : MonoBehaviour, IController
    {
        private GameData _data;
        private ObjectPool _pool;
        private int _poolSize;
        private Ball[] _balls;
        private GameObject[] _ballObjects;
        private Collider2D[] _colliders;
        private System.Random _rand;

        public SpawnerController(GameData data)
        {
            GameEventSystem.current.onBallCreate += CreateBall;
            _rand = new System.Random();
            _data = data;
            _poolSize = data.MaxBalls;
            _balls = data.Balls;
            _ballObjects = data.BallObjects;
            _colliders = data.Colliders;
            _pool = data.Pool;

            for (int i = 0; i < _poolSize; i++)
            {
                //_balls[i] = new Ball();
                data.BallObjects[i] = _pool.Pop();
                data.Colliders[i] = data.BallObjects[i].GetComponent<Collider2D>();
                _pool.Push(data.BallObjects[i]);
            }
            while (_data.ActiveBalls < _data.MaxBalls)
            {
                CreateBall(_data.ActiveBalls);
            }
        }


        private void CreateBall(int i)
        {
                _balls[i] = new Ball(_rand);
                _ballObjects[i] = _pool.Pop();
                _colliders[i] = _ballObjects[i].GetComponent<Collider2D>();
                _ballObjects[i].transform.position = _balls[i].StartPos;
                _ballObjects[i].GetComponent<SpriteRenderer>().color = _balls[i].Color;
                _ballObjects[i].transform.localScale = new Vector3(_balls[i].Scale, _balls[i].Scale, 0);
                _data.ActiveBalls++;
        }

        ~SpawnerController()
        {
            GameEventSystem.current.onBallCreate -= CreateBall;
        }
    }
}

