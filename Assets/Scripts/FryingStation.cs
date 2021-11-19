using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingStation : CookingStation
{
    // Start is called before the first frame update
    void Start()
    {
        cookTime = 40f;
        burntTime = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            timer += Time.deltaTime;
            
        }

        if (timer >= burntTime)
        {
            GameObject item = itemOnStation.GetComponent<Utensil>().itemInUtensil;
            if(item != null)
                item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.burnt;
        }
        else if (timer >= cookTime)
        {
            GameObject item = itemOnStation.GetComponent<Utensil>().itemInUtensil;
            if (item != null)
                item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.fullyCooked;
        }
    }

   
}
