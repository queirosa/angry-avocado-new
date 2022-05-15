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
                                //var dist = Vector3.Distance(GameManager.Instance.currentDrone.transform.position, transform.position);
                                //Debug.Log(dist);
                                GameManager.Instance.currentDrone.GetComponent<NavMeshAgent>().SetDestination(hit.collider.gameObject.transform.position);
                                GameManager.Instance.PlayerStats.seedCount -= 1;
                                seed.Quantity -= 1;
                                GameObject Plant = Instantiate(seed.seedPrefab, hit.collider.gameObject.transform.position, Quaternion.identity);
                                Plant.transform.parent = hit.collider.gameObject.transform;
                                Tile.hasPlante = true;
                                CancleGrow();
                            }
                            else CancleGrow();
                        }
                    }
                }
                else
                {
                    CancleGrow();
                }
            }
            else
            {
                CancleGrow();
            }
            // Clickable Object
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
    public void CancleGrow()
    {
        canGrow = false;
        currentType = SeedType.None;
        foreach (var tile in tiles.Where(c => !c.hasPlante))
        {
            tile.tileObj.GetComponent<Renderer>().material = disactiveMat;
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