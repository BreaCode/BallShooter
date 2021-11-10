using UnityEngine;
namespace BallShooter
{
    public class SpawnerTmp : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        void FixedUpdate()
        {
            if (_data.ActiveBalls < _data.MaxBalls)
            {
                GameEventSystem.current.BallCreate(_data.ActiveBalls);
            }
            else
            {
                gameObject.SetActive(false);
            }

        }
    }
}

