using System;
using TMPro;
using UnityEngine.UI;

public interface IBossHpHandler
{
    void ChangeHealth(float amount);
    void SetVisuals(TMP_Text text, Slider slider);

    event Action OnBossDefeated;
}