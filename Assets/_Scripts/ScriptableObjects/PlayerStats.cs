using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]

public class PlayerStats : ScriptableObject
{
    [Header("Years")]
    [Range(0, 10000)]
    public int years;
    [Range(0, 10000)]
    public int maxYears;
    [Range(0, 10000)]
    public float yearRate;
    [Range(0, 10000)]
    public float sleepYearRate;
    [Range(0, 10000)]
    public float walkUpYearRate;

    [Header("Water")]
    [Range(0, 10000)]
    public int water;
    [Range(0, 10000)]
    public int maxWater;

    [Header("Seeds")]
    [Range(0, 10000)]
    public int seedCount;
    [Range(0, 10000)]
    public int maxSeedCount;
    public List<Seed> avalibleSeeds;

    [Header("Oxygen")]
    [Range(0, 10000)]
    public int oxygen;
    [Range(0, 10000)]
    public int maxOxygen;

    [Header("Fertility")]
    [Range(0, 10000)]
    public int fertility;
    [Range(0, 10000)]
    public int maxFertility;

    [Header("Drones")]
    [Range(0, 10000)]
    public int numberOfDrones;
    [Range(0, 10000)]
    public int numberOfActiveDrones;

    [Range(0, 10000)]
    public int materials;

    private void OnEnable()
    {
        seedCount = avalibleSeeds.Sum(x => x.Quantity);
    }

    public void AddYears(int yearsToAdd)
    {
        if (years + yearsToAdd <= maxYears)
        {
            years += yearsToAdd;
        }
        else
        {
            years = maxYears;
        }
    }

    public void AddWater(int waterToAdd)
    {
        if (water + waterToAdd <= maxWater)
        {
            water += waterToAdd;
        }
        else
        {
            water = maxWater;
        }
    }

    public void AddOxygen(int oxygenToAdd)
    {
        if (oxygen + oxygenToAdd <= maxOxygen)
        {
            oxygen += oxygenToAdd;
        }
        else
        {
            oxygen = maxOxygen;
        }
    }

    public void AddFertility(int fertilityToAdd)
    {
        if (fertility + fertilityToAdd <= maxYears)
        {
            fertility += fertilityToAdd;
        }
        else
        {
            fertility = maxFertility;
        }
    }

    public void AddSeedCount(int seedCountToAdd)
    {
        if (seedCount + seedCountToAdd <= maxSeedCount)
        {
            seedCount += seedCountToAdd;
        }
        else
        {
            seedCount = maxSeedCount;
        }
    }

    public void SubYears(int yearsToSub)
    {
        if (years - yearsToSub >= 0)
        {
            years -= yearsToSub;
        }
        else
        {
            years = 0;
        }
    }

    public void SubWater(int waterToSub)
    {
        if (water - waterToSub >= 0)
        {
            water -= waterToSub;
        }
        else
        {
            water = 0;
        }
    }

    public void SubOxygen(int oxygenToSub)
    {
        if (oxygen - oxygenToSub >= 0)
        {
            oxygen -= oxygenToSub;
        }
        else
        {
            oxygen = 0;
        }
    }

    public void SubFertility(int fertilityToSub)
    {
        if (fertility - fertilityToSub >= 0)
        {
            fertility -= fertilityToSub;
        }
        else
        {
            fertility = 0;
        }
    }

    public void SubSeedCount(int seedCountToSub)
    {
        if (seedCount - seedCountToSub >= 0)
        {
            seedCount -= seedCountToSub;
        }
        else
        {
            seedCount = 0;
        }
    }

}
