using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NoteInteraction : MonoBehaviour
{
    private IBossHpHandler _hpController;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IBossHpHandler bossHpController, IStaticDataService staticData)
    {
        _hpController = bossHpController;
        _staticData = staticData;
    }

    private void OnMouseDown()
    {
        
        Debug.Log(gameObject.name);
        Destroy(gameObject);
        _hpController.ChangeHealth(_staticData.CurrentDifficulty.noteDamage);
    }
}
 