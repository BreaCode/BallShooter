using UnityEngine;

namespace BallShooter
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData data)
        {
            DataInitialization.Initialization(data);
            Checker checker = new Checker(data);
            Timer timer = new Timer();
            InputController input = new InputController(checker);
            SpawnerController spawner = new SpawnerController(data);
            BallsController ballsController = new BallsController(data, timer, checker);
            controllers.Add(input);
            controllers.Add(spawner);
            controllers.Add(timer);
            controllers.Add(ballsController);
        }
    }
}
