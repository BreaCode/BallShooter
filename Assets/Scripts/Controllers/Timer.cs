using UnityEngine;
namespace BallShooter
{
    public class Timer : IController, IFixed
    {
        private int _time = 0;
        public int LocalTime
        {
            get { return _time; }
        }
        public void Fixed(float deltaTime)
        {
            _time++;
            //Debug.Log(_time);
        }
    }
}

