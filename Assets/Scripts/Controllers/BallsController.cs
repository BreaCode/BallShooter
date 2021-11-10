using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallShooter
{
    internal sealed class BallsController : IController, IFixed
    {
        private Ball[] _balls;
        private GameObject[] _ballObjects;
        private GameData _data;
        private Timer _timer;
        private Checker _checker;
        private float _modifier;
        private float _speed;

        internal BallsController(GameData data, Timer timer, Checker checker)
        {
            _data = data;
            _timer = timer;
            _checker = checker;
            _balls = data.Balls;
            _ballObjects = data.BallObjects;
        }
        public void Fixed(float deltaTime)
        {
            _modifier = _timer.LocalTime / 1000;
            //Это надо было сделать через событие, но я не успел разобраться как.
            for (int i = 0; i < _data.ActiveBalls; i++)
            {
                _speed = _balls[i].Speed + _modifier;
                Vector3 delta = new Vector3(0, -_speed);
                _ballObjects[i].transform.position = _ballObjects[i].transform.position + delta;
                if (_ballObjects[i].transform.position.y <= -5)
                {
                    _data.Health--;
                    if (_data.Health < 0)
                    {
                        GameEventSystem.current.Loose();
                    }
                    else
                    {
                        GameEventSystem.current.GUIUpdate();
                        _ballObjects[i].transform.position = new Vector2(0, 0);
                        _checker.BallDestroy(_ballObjects[i]);
                    }
                }
            }

        }
    }

}
