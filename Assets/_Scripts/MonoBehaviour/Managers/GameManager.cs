using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    public PlayerStats PlayerStats;
    public List<GameObject> drones;
    public List<GameObject> availableTargets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame() {
        Debug.Log("Game has ended");
    }
}
