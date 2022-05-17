using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : StaticInstance<GameManager>
{
    public PlayerStats PlayerStats;
    public List<GameObject> drones;
    public GameObject currentDrone;
    public GameObject Player;

    public Material activeMat;
    public Material disactiveMat;
    public Material WaterdMat;

    public GameManager playerPosission;
    public GameObject Watter;
    public GameObject Base;
    float currentRate;
    // Start is called before the first frame update
    void Start()
    {
        currentRate= PlayerStats.oxygenRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRate <= 0)
        {
            GameManager.Instance.PlayerStats.oxygen -= 1;
            currentRate = PlayerStats.oxygenRate;
        }
        else
            currentRate -= 1 * Time.deltaTime;

        if (PlayerStats.oxygen == PlayerStats.maxOxygen)
        {
            Time.timeScale = 0;
            UIManager.Instance.ShowWinCanves();
        }
        if (PlayerStats.oxygen == 0)
        {
            Time.timeScale = 0;
            UIManager.Instance.ShowGameOverCanves();
        }

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
        PlayerStats.yearRate = PlayerStats.sleepYearRate;
    }
    public void WalkUp()
    {
        Player.GetComponent<NavMeshAgent>().SetDestination(playerPosission.transform.position);
        PlayerStats.yearRate = PlayerStats.walkUpYearRate;
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

    public void PLayAgain()
    {
        Player.transform.position = PlayerStats.startPostion;
        PlayerStats.Reset();
        foreach (var drone in drones)
        {
            var droneStats = drone.GetComponent<Drone>().drone;
            drone.transform.position = droneStats.startPostion;
            droneStats.Reset();
        }

    }

    void ChangeColor(GameObject unit, Material material)
    {
        foreach (var item in unit.GetComponentsInChildren<Renderer>())
        {
            item.material = material;
        }

    }
    public void EndGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowGameOverCanves();
    }
}
