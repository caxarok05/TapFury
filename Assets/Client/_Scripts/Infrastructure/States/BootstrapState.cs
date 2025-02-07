using Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "MenuScene";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadMenuState);          
        }

        public void Exit()
        {
        }

        private void EnterLoadMenuState() => _stateMachine.Enter<LoadMenuState>();

    }
}