using TMPro;
using UnityEngine.UI;

public interface IBossHpController
{
    void ChangeHealth(float amount);
    void SetText(TMP_Text text, Slider slider);
}