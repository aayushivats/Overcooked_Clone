using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStationHelper : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
       
    }

    public static bool PickupItem(Station station, Transform player)
    {
        GameObject item = station.itemOnStation;

        if (player.GetComponent<PlayerMovement>().GetItem() == null)
        {
            if (station is PickUpStation || station is PlateStation)
            {
                item = Instantiate(station.itemOnStation);
            }
            else
            {
                station.itemOnStation = null;
            }

            item.transform.parent = player;
            item.transform.position = player.position + player.forward * 1.8f;

            if (item.GetComponentInChildren<Vegetables>())
            {
                item.GetComponentInChildren<Vegetables>().startTimer = false;
            }

            player.GetComponent<PlayerMovement>().SetItem(item);

            return true;
        }
        else
        { 
            Plate plate = player.GetComponent<PlayerMovement>().GetItem().GetComponent<Plate>();
            if (plate != null)
            {
                Utensil cookingUtensil = item.GetComponent<CookingUtensil>();
                if (cookingUtensil!=null)
                {
                    if(cookingUtensil.itemInUtensil!=null)
                    {
                        Vegetables temp = cookingUtensil.itemInUtensil.GetComponent<Vegetables>();
                        if(temp.veggieState==Vegetables.VegetablesState.fullyCooked)
                        {
                           if( plate.AddItem(temp.gameObject))
                            {
                                cookingUtensil.itemInUtensil.GetComponent<Vegetables>().startTimer = false;
                                cookingUtensil.itemInUtensil.GetComponent<Vegetables>().cutTimer = 0;
                                cookingUtensil.itemInUtensil = null;

                                return true;
                            }

                        }
                    }
                }
            }
        }

        return false;
    }

    public static GameObject DropItem(Station station, Transform player)
    {
        GameObject item;
        if (player.GetComponent<PlayerMovement>().GetItem() != null)
        {
            item = player.GetComponent<PlayerMovement>().GetItem();

            Utensil utensil = null;
            if (station.itemOnStation)
            {
                utensil = station.itemOnStation.GetComponent<Utensil>();
            }

            if (utensil)
            {
                utensil.AddItem(player);
                //Update plate graphic
                return utensil.gameObject;
            }
            else
            {
                if(station is DeliveryStation && item.GetComponent<Plate>() == null)
                {
                    return null;
                }

                item.transform.parent = station.transform;
                item.transform.localPosition = new Vector3(0, 0.6f, 0);
                player.GetComponent<PlayerMovement>().SetItem(null);
                return item;
            }
        }

        return null;
    }

    public static void CutItem(GameObject itemToCut, Transform player)
    {

        //Cut
        if (itemToCut.GetComponent<Vegetables>().veggieState != Vegetables.VegetablesState.fullyCut)
        {
            player.GetComponent<PlayerMovement>().StartCuttingAnimation();
            itemToCut.GetComponent<Vegetables>().startTimer = true;
        }

    }
}
