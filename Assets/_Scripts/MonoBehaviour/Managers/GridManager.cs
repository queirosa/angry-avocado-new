using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GridManager : StaticInstance<GridManager>
{
    private Camera myCam;
    public LayerMask growingLayer;

    public List<Tile> tiles;
    public SeedType currentType;
    public Material activeMat;
    public Material disactiveMat;
    private bool canGrow = false;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canGrow)
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            // Clickable Object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, growingLayer))
            {
                var Tile = tiles.FirstOrDefault(c => c.tileObj.name == hit.collider.gameObject.name);
                if (Tile != null)
                {
                    if (!Tile.hasPlante)
                    {
                        var seed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(x => x.seedType == currentType);
                        if (seed != null)
                        {
                            if (seed.Quantity > 0)
                            {
                                if (GameManager.Instance.PlayerStats.water >= seed.watterNeed && GameManager.Instance.PlayerStats.fertility > seed.fertilityNeeded)
                                {
                                    GameManager.Instance.currentDrone.GetComponent<Drone>().drone.isWorking = true;
                                    GameManager.Instance.currentDrone.GetComponent<NavMeshAgent>().SetDestination(hit.collider.gameObject.transform.position);
                                    GameManager.Instance.PlayerStats.seedCount -= 1;
                                    seed.Quantity -= 1;
                                    GameObject Plant = Instantiate(seed.seedPrefab, hit.collider.gameObject.transform.position, Quaternion.identity);
                                    Plant.transform.parent = hit.collider.gameObject.transform;
                                    Tile.hasPlante = true;
                                    GameManager.Instance.currentDrone.GetComponent<Drone>().drone.currentJob = CurrentJob.Plante;
                                    GameManager.Instance.currentDrone.GetComponent<Drone>().drone.WorkingText = "Growing " + seed.seedName;
                                    UIManager.Instance.ActiveWorkingPanle();
                                }
                                CancleGrow(true);
                            }
                            else CancleGrow(false);
                        }
                    }
                }
                else
                {
                    CancleGrow(false);
                }
            }
            else
            {
                CancleGrow(false);
            }
        }
    }
    public void Grow(SeedType seedType)
    {
        canGrow = true;
        currentType = seedType;
        foreach (var tile in tiles.Where(c => !c.hasPlante))
        {
            tile.tileObj.GetComponent<Renderer>().material = activeMat;
        }
    }
    public void CancleGrow(bool finshed)
    {
        canGrow = false;
        currentType = SeedType.None;
        foreach (var tile in tiles.Where(c => !c.hasPlante))
        {
            tile.tileObj.GetComponent<Renderer>().material = disactiveMat;
        }
        if (!finshed)
        {
            UIManager.Instance.ActiveActionPanle();
        }
    }

}





public enum SeedType
{
    None = 0,
    Conifer = 1,
    Flower = 2,
    Fruit = 3,
    Jungle = 4
}