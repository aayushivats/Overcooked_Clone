using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingStation : CookingStation
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (itemOnStation)
        {
            Vegetables veg = itemOnStation.GetComponentInChildren<Vegetables>();
            if (veg != null)
            {
                GameObject item = itemOnStation.GetComponent<Utensil>().itemInUtensil;
                if (item != null)
                {
                    if (item.GetComponent<Vegetables>().timer >= burntTime)
                    {
                        item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.burnt;
                        item.transform.GetChild(1).gameObject.SetActive(false);
                        item.transform.GetChild(2).gameObject.SetActive(true);

                        item.GetComponent<Vegetables>().startTimer = false;
                    }
                    else if (item.GetComponent<Vegetables>().timer >= cookTime)
                    {
                        item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.fullyCooked;
                    }
                }

            }
        }
    }

   
}
