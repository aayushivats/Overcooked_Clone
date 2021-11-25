using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryStation : Station,IDrop
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropItem()
    {
        GameObject temp = IStationHelper.DropItem(this);

        if (temp)
        {
            if (temp.GetComponent<Plate>() != null && temp.GetComponent<Plate>().itemInUtensil != null)
            {
                score += 10;
                Destroy(temp);
                
            }
            else
            {
                Debug.Log("No Plate");
                if (score >= 10)
                {
                    score -= 10;
                }
                else
                    score = 0;

            }
            scoreText.text = score.ToString();
        }
    }

    public override bool DoPickupDrop()
    {
        DropItem();
        return true;
    }
}
