using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanteController : MonoBehaviour
{
    public Seed Seed;
    float currentRate;
    int index = 0;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        time = Seed.timeSpan;
        currentRate = GameManager.Instance.PlayerStats.yearRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            if (currentRate <= 0)
            {
                time -= 1;
                currentRate = GameManager.Instance.PlayerStats.yearRate;

            }
            else
                currentRate -= 1 * Time.deltaTime;

            if (index < Seed.phases.Count())
            {
                if (time == Seed.timeSpan / (index + 1))
                {
                    index++;
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    GameObject Plant = Instantiate(Seed.phases[index], gameObject.transform.position, Quaternion.identity);
                    Plant.transform.parent = gameObject.transform;
                    GameManager.Instance.PlayerStats.fertility += Seed.fertilityPreduce / Seed.phases.Count();
                    GameManager.Instance.PlayerStats.oxygen += Seed.oxygenPreduce / Seed.phases.Count();
                    GameManager.Instance.PlayerStats.materials += Seed.materialsPreduce / Seed.phases.Count();
                    var currentSeed = GameManager.Instance.PlayerStats.avalibleSeeds.FirstOrDefault(c => c.seedType == Seed.seedType);
                    if (currentSeed != null)
                    {
                        currentSeed.Quantity += Seed.seedPreduce;
                    }
                    else
                    {
                        Seed.Quantity = Seed.seedPreduce;
                        GameManager.Instance.PlayerStats.avalibleSeeds.Add(Seed);
                    }
                    Debug.Log("Phase " + index);
                }
            }
        }
        else
        {
            var tile = GridManager.Instance.tiles.FirstOrDefault(c => c.tileObj == gameObject.transform.parent.gameObject);
            tile.hasPlante = false;
            gameObject.transform.parent.gameObject.GetComponent<Renderer>().material =
                GridManager.Instance.disactiveMat;
            //  gameObject.GetComponentInParent<>
            Destroy(gameObject);
        }

    }
}
