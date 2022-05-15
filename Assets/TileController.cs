using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridManager.Instance.tiles.Add(new Tile { tileObj = this.gameObject, hasPlante = false });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
