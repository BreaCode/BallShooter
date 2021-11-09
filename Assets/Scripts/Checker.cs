using UnityEngine;
namespace BallShooter
{
    internal sealed class Checker
    {
        private GameData _data;
        private Collider2D[] _colliders;
        internal Checker(GameData data)
        {
            _data = data;
            _colliders = data.Colliders;
        }
        public void Check(Vector3 mousePos)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i].bounds.Contains(mousePos))
                {
                    //Debug.Log("Boom");
                    BallDestroy(_colliders[i].gameObject, i);
                }
            }
        }

        public void BallDestroy(GameObject ball, int index)
        {
            GameObject tmp = _data.BallObjects[_data.ActiveBalls];
            _data.BallObjects[_data.ActiveBalls] = ball;
            _data.BallObjects[index] = tmp;
            _data.BallObjects[_data.ActiveBalls].SetActive(false);
            _data.ActiveBalls--;
            Debug.Log(_data.ActiveBalls);
        }
    }
}

