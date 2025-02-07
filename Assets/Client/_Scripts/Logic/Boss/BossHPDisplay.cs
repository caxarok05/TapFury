using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BossHPDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    private IBossHpController _hpController;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IBossHpController bossHpController, IStaticDataService staticData)
    {
        _hpController = bossHpController;
        _staticData = staticData;
    }
    public void Start()
    {
        var difficulty = _staticData.ForDifficulty(1);
        _text.text = difficulty.bossHp.ToString();
        _slider.maxValue = difficulty.bossHp;
        _slider.value = _slider.maxValue;
        _hpController.SetText(_text, _slider);
    }
}
