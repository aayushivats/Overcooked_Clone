using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingStation : Station, IPickup, IDrop
{
    public float burntTime = 10.2f;
    public float cookTime = 40.1f;
    private Slider timerUI;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        timerUI = GetComponentInChildren<Slider>();
        timerUI.gameObject.SetActive(false);

    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if (itemOnStation)
        {
            Vegetables veg = itemOnStation.GetComponentInChildren<Vegetables>();
            if (veg != null)
            {
                timerUI.value = veg.cutTimer / cookTime;

                GameObject item = itemOnStation.GetComponent<Utensil>().itemInUtensil;
                if (item != null)
                {
                    if (item.GetComponent<Vegetables>().cutTimer >= burntTime)
                    {
                        item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.burnt;
                        item.transform.GetChild(1).gameObject.SetActive(false);
                        item.transform.GetChild(2).gameObject.SetActive(true);

                        item.GetComponent<Vegetables>().startTimer = false;
                    }
                    else if (item.GetComponent<Vegetables>().cutTimer >= cookTime)
                    {
                        item.GetComponent<Vegetables>().veggieState = Vegetables.VegetablesState.fullyCooked;
                    }
                }

            }
        }
    }

    public void PickupItem()
    {
        Transform player = GameController.GetPlayer();
        if ((player.GetComponent<PlayerMovement>().GetItem() && player.GetComponent<PlayerMovement>().GetItem().GetComponent<Plate>() != null)
            || player.GetComponent<PlayerMovement>().GetItem() == null)
        {
            IStationHelper.PickupItem(this);
            timerUI.gameObject.SetActive(false);
        }
    }

    public void DropItem()
    {
        //startTimer = true;
        GameObject temp = IStationHelper.DropItem(this);
        if (temp)
        {
            itemOnStation = temp;
            Vegetables veg= itemOnStation.GetComponentInChildren<Vegetables>();
            if (veg != null)
            {
                if (veg.veggieState >= Vegetables.VegetablesState.fullyCut)
                {
                    veg.startTimer = true;
                }
                timerUI.gameObject.SetActive(true);
            }
            itemOnStation.transform.SetParent(transform);
        }
    }

    public override bool DoPickupDrop()
    {
        Transform player = GameController.GetPlayer();
        if (isOccupied)
        {
            //itemonstaion is plate?
            if (itemOnStation.GetComponent<CookingUtensil>() != null)
            {
                //if player has something in hand then dropitem
                if (player.GetComponent<PlayerMovement>().GetItem() && player.GetComponent<PlayerMovement>().GetItem().GetComponent<Vegetables>() != null)
                {
                    DropItem();
                    return true;
                }
                else
                {
                    PickupItem();
                }
            }
            //else if player hand is empty then pick item
            
        }
        else
        {
            if (player.GetComponentInChildren<CookingUtensil>())
                DropItem();
        }
        return true;
    }
}

