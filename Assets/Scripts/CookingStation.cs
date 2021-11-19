using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : Station, IPickup, IDrop
{
    public float timer = 0;
    public float burntTime = 10.2f;
    public float cookTime = 4.1f;

    public bool startTimer = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickupItem()
    {
        Transform player = GameController.GetPlayer();
        if ((player.GetComponent<PlayerMovement>().GetItem() && player.GetComponent<PlayerMovement>().GetItem().GetComponent<Plate>() != null)
            || player.GetComponent<PlayerMovement>().GetItem() == null)
        {
            IStationHelper.PickupItem(this);
        }
    }

    public void DropItem()
    {
        startTimer = true;
        GameObject temp = IStationHelper.DropItem(this);
        if (temp)
        {
            Debug.Log(temp);
            itemOnStation = temp;
            
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
            Debug.Log("No Cooking Utensil");
        }
        return true;
    }
}

