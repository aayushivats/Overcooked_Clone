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
            station.itemOnStation = null;
        }

        if (player.GetComponent<PlayerMovement>().GetItem() == null)
        {
            item.transform.parent = player.transform;
            item.transform.position = player.position + player.transform.forward * 2.5f;
            item.transform.rotation = Quaternion.identity;
            //item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
           
            player.GetComponent<PlayerMovement>().SetItem(item);
        }

        else if(player.GetComponent<PlayerMovement>().GetItem()!=null)
        {
            if(station is FryingStation)
            {
                item.transform.parent = player.transform;
                item.transform.position = player.position + player.transform.forward * 2.5f;
                item.transform.rotation = Quaternion.identity;
                //item.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

                player.GetComponent<PlayerMovement>().SetItem(item);
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

            Plate plate = null;
            if (station.itemOnStation)
            {
                plate = station.itemOnStation.GetComponent<Plate>();
            }

            if (plate)
            {
                plate.AddItem();
                //Update plate graphic
                return plate.gameObject;
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
