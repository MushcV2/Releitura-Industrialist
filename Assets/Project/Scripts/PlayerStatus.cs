using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private TMP_Text moneyTXT;
    [SerializeField] private TMP_Text scienceTXT;
    [SerializeField] private int money;
    [SerializeField] private int sciencePoint;

    private void Start()
    {
        UpdateText("money");
        UpdateText("science");
    }

    public void GainStatus(int _value, string _type)
    {
        switch (_type)
        {
            case "money":
                money += _value;
                break;

            case "science":
                sciencePoint += _value;
                break;
        }

        UpdateText(_type);
    }

    public void LostStatus(int _value, string _type)
    {
        switch (_type)
        {
            case "money":
                money = Mathf.Max(money - _value, 0);
                break;

            case "science":
                sciencePoint = Mathf.Max(sciencePoint - _value, 0);
                break;
        }

        UpdateText(_type);
    }

    private void UpdateText(string _type)
    {
        switch (_type)
        {
            case "money":
                moneyTXT.text = "$" + money.ToString();
                break;

            case "science":
                scienceTXT.text = sciencePoint.ToString();
                break;
        }
    }
}