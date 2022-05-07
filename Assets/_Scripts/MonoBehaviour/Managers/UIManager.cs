using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : StaticInstance<UIManager>
{

    public TextMeshProUGUI waterText;
    public TextMeshProUGUI seedCountText;
    public TextMeshProUGUI fertilityText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI yearsText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waterText.text = GameManager.Instance.PlayerStats.water.ToString();
        seedCountText.text = GameManager.Instance.PlayerStats.seedCount.ToString();
        fertilityText.text = GameManager.Instance.PlayerStats.fertility.ToString();
        oxygenText.text = GameManager.Instance.PlayerStats.oxygen.ToString();
        yearsText.text = GameManager.Instance.PlayerStats.years.ToString();
    }
}
