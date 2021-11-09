using UnityEngine;

namespace BallShooter 
{
    internal sealed class SpawnerController : MonoBehaviour, IController, IFixed
    {
        private GameData _data;
        private Transform _poolParent;
        private int _currentPoolID = 0;
        private int _poolSize = 100;
        private GameObject _prefab;
        private Ball[] _balls;
        private GameObject[] _ballObjects; 

        public SpawnerController(GameData data)
        {
            _data = data;
            _balls = data.Balls;
            _prefab = data.Prefab;
            _poolParent = data.OriginTransform;

            _ballObjects = new GameObject[_poolSize];
            for (int i = 0; i < _poolSize; i++)
            {
                _balls[i] = new Ball();
                _ballObjects[i] = Instantiate(_prefab, _poolParent);
                data.BallObjects[i] = _ballObjects[i];
                data.Colliders[i] = _ballObjects[i].GetComponent<Collider2D>();
                _ballObjects[i].SetActive(false);
            }
            data.ActiveBalls = 0;
        }

        public void Fixed(float deltaTime)
        {
            if (_data.ActiveBalls <= 30)
            {
                CreateBall();
                if (_data.ActiveBalls > 0)
                {
                    //Это костыль против слишком быстрого спавна.
                    if (_balls[_data.ActiveBalls] == _balls[_data.ActiveBalls - 1])
                    {
                        _data.ActiveBalls--;
                        CreateBall();
                    }
                }
            }
        }

        private void CreateBall()
        {
            int i = _data.ActiveBalls;
            _balls[i] = new Ball();
            _ballObjects[i].transform.position = _balls[i].StartPos;
            _ballObjects[i].GetComponent<SpriteRenderer>().color = _balls[i].Color;
            _ballObjects[i].transform.localScale = new Vector3(_balls[i].Scale, _balls[i].Scale, 0);
            _ballObjects[i].SetActive(true);
            _data.ActiveBalls++;
        }

    }
}

