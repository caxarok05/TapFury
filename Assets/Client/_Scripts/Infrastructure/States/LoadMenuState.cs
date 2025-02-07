using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Infrastructure.States
{
    public class LoadMenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;

        public LoadMenuState(GameStateMachine stateMachine, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            onLoaded();
            Debug.Log("succesLoadMenu");
        }

        public void Exit()
        {
        }

        private async void onLoaded()
        {
            await InitUIRoot();
        }
        private async Task InitUIRoot() => await _uiFactory.CreateUIMenuRoot();
    }
}