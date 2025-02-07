using Scripts.Infrastructure.Factory;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, GameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader; 
            _gameFactory = gameFactory;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, onLoaded);
        }

        public void Exit()
        {
        }
        private async void onLoaded()
        {
            await _gameFactory.CreateCamera();
            await _gameFactory.CreateHud();
            await _gameFactory.CreateNoteSpawner();
        }
    }
}
