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

    public static void PickupItem(Station station)
    {
        Transform player = GameController.GetPlayer();
        GameObject item;
        if (station is PickUpStation)
        {
            item = Instantiate(station.itemOnStation);
        }
        else
        {
            item = station.itemOnStation;
        }

        if (player.GetComponent<PlayerMovement>().GetItem() == null)
        {
            item.transform.parent = player.transform;
            item.transform.position = player.position + player.transform.forward * 2.5f;
            item.transform.rotation = Quaternion.identity;
            //item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            player.GetComponent<PlayerMovement>().SetItem(item);
            station.itemOnStation = null;
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
                                cookingUtensil.itemInUtensil = null;
                                ((CookingStation)station).startTimer = false;
                                ((CookingStation)station).timer = 0;
                            }

                        }
                    }
                }
            }
        }
        
    }

    public static GameObject DropItem(Station station)
    {
        Transform player = GameController.GetPlayer();
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
                utensil.AddItem();
                //Update plate graphic
                return utensil.gameObject;
            }
            else
            {
                item.transform.parent = station.transform;
                item.transform.localPosition = new Vector3(0, 0.6f, 0);
                player.GetComponent<PlayerMovement>().SetItem(null);
                return item;
            }
        }

        return null;
    }

    public static void CutItem(GameObject itemToCut)
    {
        Transform player = GameController.GetPlayer();

        //Cut
        if (itemToCut.GetComponent<Vegetables>().veggieState != Vegetables.VegetablesState.fullyCut)
        {
            player.GetComponent<PlayerMovement>().StartCuttingAnimation();
            itemToCut.GetComponent<Vegetables>().startTimer = true;

        }

    }
}
