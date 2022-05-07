using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]

public class PlayerStats : ScriptableObject
{
    public int years;
    public int water;
    public int seedCount;
    public int oxygen;
    public int fertility;

    public int numberOfDrones;

    public int numberOfActiveDrones;

    public int maxYears;
    public int maxWater;
    public int maxOxygen;
    public int maxSeedCount;
    public int maxFertility;

    public void addYears(int yearsToAdd) {
        if(years + yearsToAdd <= maxYears) {
            years += yearsToAdd;
        } else {
            years = maxYears;
        }
    }

    public void addWater(int waterToAdd) {
        if(years + waterToAdd <= maxWater) {
            water += waterToAdd;
        } else {
            water = maxWater;
        }
    }

    public void addOxygen(int oxygenToAdd) {
        if(years + oxygenToAdd <= maxOxygen) {
            oxygen += oxygenToAdd;
        } else {
            oxygen = maxOxygen;
        }
    }

    public void addFertility(int fertilityToAdd) {
        if(years + fertilityToAdd <= maxYears) {
            fertility += fertilityToAdd;
        } else {
            fertility = maxFertility;
        }
    }

    public void addSeedCount(int seedCountToAdd) {
        if(seedCount + seedCountToAdd <= maxSeedCount) {
            seedCount += seedCountToAdd;
        } else {
            seedCount = maxSeedCount;
        }
    }

    public void subYears(int yearsToSub) {
        if(years - yearsToSub >= 0) {
            years -= yearsToSub;
        } else {
            years = 0;
        }
    }

    public void subWater(int waterToSub) {
        if(water - waterToSub >= 0) {
            water -= waterToSub;
        } else {
            water = 0;
        }
    }

    public void subOxygen(int oxygenToSub) {
        if(oxygen - oxygenToSub >= 0) {
            oxygen -= oxygenToSub;
        } else {
            oxygen = 0;
        }
    }

    public void subFertility(int fertilityToSub) {
        if(fertility - fertilityToSub >= 0) {
            fertility -= fertilityToSub;
        } else {
            fertility = 0;
        }
    }

    public void subSeedCount(int seedCountToSub) {
        if(seedCount - seedCountToSub >= 0) {
            seedCount -= seedCountToSub;
        } else {
            seedCount = 0;
        }
    }

}
