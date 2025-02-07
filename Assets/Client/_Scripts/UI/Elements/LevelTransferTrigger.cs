using Scripts.Infrastructure.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelTransferTrigger : MonoBehaviour
{
    public string TransferTo;
    private IGameStateMachine _gameStateMachine;

    [Inject]
    public void Construct(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Transfer()
    {
        _gameStateMachine.Enter<LoadLevelState, string>(TransferTo);
    }
}
