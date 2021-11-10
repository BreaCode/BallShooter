using UnityEngine;
namespace BallShooter
{
    internal sealed class Checker
    {
        private GameData _data;
        private Collider2D[] _colliders;
        private ObjectPool _pool;
        internal Checker(GameData data)
        {
            _data = data;
            _colliders = data.Colliders;
            _pool = data.Pool;
        }
        public void Check(Vector3 mousePos)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i].bounds.Contains(mousePos))
                {
                    //Debug.Log("Boom");
                    BallDestroy(_colliders[i].gameObject);
                }
            }
        }

        public void BallDestroy(GameObject ball)
        {
            _pool.Push(ball);
            _data.ActiveBalls--;
            //Ќе понимаю почему их становитс€ меньше
            Debug.Log(_data.ActiveBalls);
        }
    }
}

