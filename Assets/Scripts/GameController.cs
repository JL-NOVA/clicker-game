using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public TMP_Text CurrentCurrenyText;
    public float Currency = 0f;

    private float _currencyPreviousSecond;
    private float _currentPerSecond;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        InvokeRepeating("UpdatePerSecond", 1f, 1f);
    }

    void Update()
    {
        CurrentCurrenyText.text = Currency.ToString("F0") + " Points" + " (" + _currentPerSecond.ToString("F0") + " Points/s)";
    }

    void UpdatePerSecond()
    {
        _currentPerSecond = Currency - _currencyPreviousSecond;
        _currencyPreviousSecond = Currency;
    }

    public void ClickClicker()
    {
        Currency += 1f;
    }
}
