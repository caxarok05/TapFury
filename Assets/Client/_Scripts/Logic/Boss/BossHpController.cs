using Scripts.Infrastructure.Factory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHpController : IBossHpController
{
    private TMP_Text _text;
    private Slider _slider;

    public void ChangeHealth(float amount)
    {
        _text.text = (int.Parse(_text.text) - amount).ToString();
        _slider.value -= amount;
    }

    public void SetText(TMP_Text text, Slider slider)
    {
        _text = text;
        _slider = slider;
    }
}

