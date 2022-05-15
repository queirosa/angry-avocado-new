using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : StaticInstance<GameManager>
{
    public PlayerStats PlayerStats;
    public List<GameObject> drones;
    public GameObject currentDrone;
    public GameObject Player;

    public Material activeMat;
    public Material disactiveMat;
    public GameManager playerPosission;
    public GameObject Watter;
    public GameObject Base;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectDrone(GameObject drone)
    {
        currentDrone = null;
        currentDrone = drone;
        DeSelectAll();
        ChangeColor(currentDrone, activeMat);
    }
    public void Sleep()
    {
        Player.GetComponent<NavMeshAgent>().SetDestination(Base.transform.position);
    }
    public void WalkUp()
    {
        Player.GetComponent<NavMeshAgent>().SetDestination(playerPosission.transform.position);
    }
    public void GoToBase(GameObject gameObject)
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(Base.transform.position);
    }
    public void DeSelectAll()
    {
        foreach (var item in drones.Where(c => c != currentDrone))
        {
            ChangeColor(item, disactiveMat);
        }
    }

    public void GoPlante(Seed seed, Tile tile, Transform transformm)
    {
        

    }

    void ChangeColor(GameObject unit, Material material)
    {

        unit.GetComponent<Renderer>().material = material;
    }
    public void EndGame()
    {
        Debug.Log("Game has ended");
    }
}
