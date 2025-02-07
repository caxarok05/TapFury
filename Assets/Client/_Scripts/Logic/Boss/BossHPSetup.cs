using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BossHPSetup : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    private IBossHpHandler _hpHandler;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IBossHpHandler bossHpHandler, IStaticDataService staticData)
    {
        _hpHandler = bossHpHandler;
        _staticData = staticData;
    }
    public void Start()
    {
        var difficulty = _staticData.CurrentDifficulty;
        SetVisuals(difficulty);

        _hpHandler.SetVisuals(_text, _slider);
    }

    private void SetVisuals(DifficultyStaticData difficulty)
    {
        _text.text = difficulty.bossHp.ToString();
        _slider.maxValue = difficulty.bossHp;
        _slider.value = _slider.maxValue;
    }
}
