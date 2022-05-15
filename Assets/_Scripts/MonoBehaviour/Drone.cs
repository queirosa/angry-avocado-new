using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            GameManager.Instance.PlayerStats.AddWater(drone.currentWater);
            drone.currentWater = 0;
        }
    }

    //private void OnDestroy()
    //{
    //    GameManager.Instance.drones.Remove(this.gameObject);
    //}
}
