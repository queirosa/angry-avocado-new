using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

using TMPro;
using System;
using System.Linq;

public class UIManager : StaticInstance<UIManager>
{

    public TextMeshProUGUI waterText;
    public TextMeshProUGUI seedCountText;
    public TextMeshProUGUI fertilityText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI yearsText;
    public Button SleepButton;
    public Button WalkUpButton;

    public TextMeshProUGUI ConiferCount;
    public TextMeshProUGUI FlowerCount;
    public TextMeshProUGUI FruitCount;
    public TextMeshProUGUI JungleCount;

    public Button ConiferButton;
    public Button FlowerButton;
    public Button FruitButton;
    public Button JungleButton;

    private float currentRate;
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
        var coniferSeed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(x => x.seedType == SeedType.Conifer);
        var flowerSeed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(x => x.seedType == SeedType.Flower);
        var fruitSeed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(x => x.seedType == SeedType.Fruit);
        var jungleSeed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(x => x.seedType == SeedType.Jungle);
        ConiferCount.text = "( " + coniferSeed.Quantity + " )";
        FlowerCount.text = "( " + flowerSeed.Quantity + " )";
        FruitCount.text = "( " + fruitSeed.Quantity + " )";
        JungleCount.text = "( " + jungleSeed.Quantity + " )";
        ConiferButton.enabled = coniferSeed.Quantity > 0;
        FlowerButton.enabled = flowerSeed.Quantity > 0;
        FruitButton.enabled = fruitSeed.Quantity > 0;
        FruitButton.enabled = jungleSeed.Quantity > 0;

        waterText.text = playerStats.water.ToString();
        seedCountText.text = playerStats.seedCount.ToString();
        fertilityText.text = playerStats.fertility.ToString();
        oxygenText.text = playerStats.oxygen.ToString();
        yearsText.text = playerStats.years.ToString();
        CalculateYearLeft();
        if (GameManager.Instance.PlayerStats.years == 0)
        {
            GameManager.Instance.EndGame();
        }
    }
    public void Sleep()
    {
        GameManager.Instance.Sleep();
        SleepButton.gameObject.SetActive(false);
        WalkUpButton.gameObject.SetActive(true);

    }
    public void WalkUp()
    {
        GameManager.Instance.WalkUp();
        SleepButton.gameObject.SetActive(true);
        WalkUpButton.gameObject.SetActive(false);

    }
    public void GrowConifer()
    {
        GridManager.Instance.Grow(SeedType.Conifer);
    }
    public void GrowFlower()
    {
        GridManager.Instance.Grow(SeedType.Flower);
    }
    public void GrowFruit()
    {
        GridManager.Instance.Grow(SeedType.Fruit);
    }
    public void GrowJungle()
    {
        GridManager.Instance.Grow(SeedType.Jungle);
    }
    private void CalculateYearLeft()
    {
        if (currentRate <= 0)
        {
            GameManager.Instance.PlayerStats.years -= 1;
            currentRate = playerStats.yearRate;
        }
        else
            currentRate -= 1 * Time.deltaTime;
    }
    public void SelectDrone(GameObject drone)
    {
        GameManager.Instance.SelectDrone(drone);
    }
    public void GetWater(int amount)
    {
        if (GameManager.Instance.currentDrone != null)
        {
            GameManager.Instance.currentDrone.GetComponent<Drone>().drone.maxAmountOfWater = amount;
            GameManager.Instance.currentDrone.GetComponent<NavMeshAgent>().SetDestination(GameManager.Instance.Watter.transform.position);
        }
    }
}
