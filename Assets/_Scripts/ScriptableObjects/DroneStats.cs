using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DroneStats", menuName = "ScriptableObjects/Drone01", order = 1)]

public class DroneStats : ScriptableObject
{
    public float Effectiveness = 1;
    public int currentWater = 0;
    public int waterPerYear = 100;
    public int maxAmountOfWater = 1000;
    public bool isWorking = false;
    public string WorkingText = "";
    public CurrentJob currentJob = CurrentJob.Idle;
}

[System.Serializable]
public enum CurrentJob
{
    Idle = 0,
    GatheringWater = 1,
    Plante = 2,
    Harvesed = 3
}