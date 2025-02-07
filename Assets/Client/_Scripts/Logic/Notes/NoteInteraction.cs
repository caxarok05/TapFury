using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NoteInteraction : MonoBehaviour
{
    private IBossHpController _hpController;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IBossHpController bossHpController, IStaticDataService staticData)
    {
        _hpController = bossHpController;
        _staticData = staticData;
    }

    private void OnMouseDown()
    {
        
        Debug.Log(gameObject.name);
        Destroy(gameObject);
        _hpController.ChangeHealth(_staticData.ForDifficulty(1).noteDamage);
    }
}
 