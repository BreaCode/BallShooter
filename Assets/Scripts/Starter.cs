using UnityEngine;
namespace BallShooter
{
    internal sealed class Starter : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private Controllers _controllers;
        void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _gameData);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Fixed(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Clean();
        }
    }
}

