using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public float Cost = 10f;
    public int Amount = 0;
    public float CurrencyPerSecond = 1f;
    public float CostMultiplier = 1f;

    public TMP_Text Cost_Text;
    public TMP_Text Amount_Text;

    public void Buy()
    {
        if (GameController.Instance.Currency >= Cost)
        {
            GameController.Instance.Currency -= Cost;
            Cost *= CostMultiplier;
            Amount++;
            Amount_Text.text = Amount.ToString();
            Cost_Text.text = Cost.ToString("F0");
        }
    }

    void Start()
    {
        InvokeRepeating("Collect", 1f, 1f);
    }
    void Collect()
    {
        GameController.Instance.Currency += CurrencyPerSecond * Amount;
    }
}