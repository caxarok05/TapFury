using Scripts.Infrastructure.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHpHandler : IBossHpHandler
{
    public event Action OnBossDefeated;

    private TMP_Text _text;
    private Slider _slider;

    private float currentHp;
    
    public BossHpHandler(IStaticDataService staticDataService)
    {
        currentHp = staticDataService.CurrentDifficulty.bossHp;
    }

    public void ChangeHealth(float amount)
    {
        if (currentHp - amount > 0)
        {
            currentHp -= amount;
            ChangeVisuals();
        }
        else
        {
            currentHp = 0;
            ChangeVisuals();

            OnBossDefeated?.Invoke();
        }     
    }

    public void SetVisuals(TMP_Text text, Slider slider)
    {
        _text = text;
        _slider = slider;
    }

    private void ChangeVisuals()
    {
        _text.text = currentHp.ToString();
        _slider.value = currentHp;
    }


}

