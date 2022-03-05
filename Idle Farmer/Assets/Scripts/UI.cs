using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField] private float _shakeDurationCoinHandler = .1f;

    [SerializeField] private float _shakeStrangeCoinHandler = .5f;

    [SerializeField] private int _shakeVibratoCoinHandler = 5;

    [SerializeField] private float _shakeRandomnessCoinHandler = 45f;

    [SerializeField] private TextMeshProUGUI _coin;

    [SerializeField] private Slider _stack;

    [SerializeField] private Character _character;

    private float _originalSize;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _originalSize = _coin.transform.localScale.y;

        _character.CoinsChangeEvent += UpdateCoinText;

        _character.StackChangeEvent += UpdateStackValue;
    }

    private void UpdateCoinText(string value)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_coin.transform.DOShakeScale(_shakeDurationCoinHandler, _shakeStrangeCoinHandler, _shakeVibratoCoinHandler, _shakeRandomnessCoinHandler));

        sequence.Append(_coin.transform.DOScale(_originalSize, _shakeDurationCoinHandler));

        _coin.text = value;
    }

    private void UpdateStackValue(int value)
    {
        _stack.value = value;
    }
}
