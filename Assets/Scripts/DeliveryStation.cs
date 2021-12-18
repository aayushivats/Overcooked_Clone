using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryStation : Station,IDrop
{
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
            if (temp.GetComponent<Plate>() != null)
            {
                if (temp.GetComponent<Plate>().itemInUtensil != null)
                {
                    Vegetables veg = temp.GetComponent<Plate>().itemInUtensil.GetComponent<Vegetables>();
                    if (LevelManager.instance.IsValidRecipe(new Recipe(veg.name, veg.veggieState)))
                    {
                        GameController.instance.AddScore(10);
                    }
                    else
                    {
                        Debug.Log("Wrong Recipe");
                        GameController.instance.AddScore(-10);
                    }
                }
                else
                {
                    Debug.Log("Empty Plate");
                    GameController.instance.AddScore(-10);
                }

                Destroy(temp);
            }
            else
            {
                Debug.Log("No Plate");
            }
            scoreText.text = GameController.instance.GetScore().ToString();
        }
    }

    public override bool DoPickupDrop()
    {
        DropItem();
        return true;
    }
}
