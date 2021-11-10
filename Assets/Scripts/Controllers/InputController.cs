using UnityEngine;
namespace BallShooter
{
    internal sealed class InputController : IController, IExecute
    {
        private Vector3 _mousepos;
        private Checker _checker;

        internal InputController(Checker checker)
        {
            _checker = checker;
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _mousepos = new Vector3(_mousepos.x, _mousepos.y, 0);
                _checker.Check(_mousepos);
            }

        }
    }
}

