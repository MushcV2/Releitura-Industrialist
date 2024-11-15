using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private TMP_Text moneyTXT;
    [SerializeField] private TMP_Text scienceTXT;
    public int money;
    public int sciencePoint;

    private void Start()
    {
        UpdateText("money");
        UpdateText("science");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GainStatus(1000, "money");
            GainStatus(1000, "science");
        }
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
                moneyTXT.text = "$" + money.ToString("N0");
                break;

            case "science":
                scienceTXT.text = sciencePoint.ToString("N0") + "RP";
                break;
        }
    }
}