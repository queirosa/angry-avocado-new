using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static GameManager;

public class Drone : MonoBehaviour
{
    public DroneStats drone;
    private float currentRate;
    void Start()
    {
        GameManager.Instance.drones.Add(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Water");
            if (currentRate <= 0)
            {
                if (drone.currentWater >= drone.maxAmountOfWater)
                {
                    GameManager.Instance.GoToBase(this.gameObject);
                }
                else
                    drone.currentWater += drone.waterPerYear;
                currentRate = GameManager.Instance.PlayerStats.yearRate;
            }
            else
                currentRate -= 1 * Time.deltaTime;
        }
        if (other.gameObject.CompareTag("Base"))
        {
            Debug.Log("Base");
            switch (drone.currentJob)
            {
                case CurrentJob.Idle:
                    break;
                case CurrentJob.GatheringWater:
                    GameManager.Instance.PlayerStats.AddWater(drone.currentWater);
                    break;
                case CurrentJob.Plante:
                    break;
                case CurrentJob.Harvesed:
                    break;
            }
            drone.currentWater = 0;
            drone.isWorking = false;
            drone.currentJob = CurrentJob.Idle;
            if (GameManager.Instance.currentDrone == this.gameObject)
            {
                UIManager.Instance.ActiveActionPanle();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            Debug.Log("Seed");
            Seed seed = other.gameObject.GetComponent<PlanteController>().Seed;
            GameManager.Instance.PlayerStats.water -= seed.watterNeed;
            GameManager.Instance.PlayerStats.fertility -= seed.fertility;
            ////other.gameObject.GetComponentInParent<Renderer>().material = GameManager.Instance.WaterdMat;
            GameManager.Instance.GoToBase(this.gameObject);
            //drone.isWorking = false;
            //drone.currentJob = CurrentJob.Idle;
        }
    }
    //private void OnDestroy()
    //{
    //    GameManager.Instance.drones.Remove(this.gameObject);
    //}
}
