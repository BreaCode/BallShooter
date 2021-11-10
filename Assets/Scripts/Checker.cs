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
                    _data.Score++;
                    GameEventSystem.current.GUIUpdate();
                    BallDestroy(_colliders[i].gameObject, i);
                }
            }
        }

        public void BallDestroy(GameObject ball, int index)
        {
            _pool.Push(ball);
            _data.ActiveBalls--;
            GameEventSystem.current.BallCreate(index);
        }
    }
}

