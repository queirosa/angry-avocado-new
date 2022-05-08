using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : StaticInstance<UIManager>
{

    public TextMeshProUGUI waterText;
    public TextMeshProUGUI seedCountText;
    public TextMeshProUGUI fertilityText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI yearsText;

    private int currentRate;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameManager.Instance.PlayerStats;
        currentRate = playerStats.yearRate;
    }

    // Update is called once per frame
    void Update()
    {
        waterText.text = playerStats.water.ToString();
        seedCountText.text = playerStats.seedCount.ToString();
        fertilityText.text = playerStats.fertility.ToString();
        oxygenText.text = playerStats.oxygen.ToString();
        yearsText.text = playerStats.years.ToString();
        CalculateYearLeft();
    }

    private void CalculateYearLeft()
    {
        if (currentRate <= 0)
        {
            GameManager.Instance.PlayerStats.years--;
            currentRate = playerStats.yearRate;
        }
        else
            currentRate--;
    }
}
