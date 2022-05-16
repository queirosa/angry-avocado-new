using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Seed", menuName = "ScriptableObjects/Seed", order = 1)]
public class Seed : ScriptableObject
{
    public string seedName;
    public int Quantity;
    public GameObject seedPrefab;
    public SeedType seedType;
    public int timeSpan;
    public int watterNeed;
    public int oxygenPreduce;
    public int fertilityNeeded;
    public int materialsPreduce;
    public int fertilityPreduce;
    public int seedPreduce;
    public List<GameObject> phases;
}
