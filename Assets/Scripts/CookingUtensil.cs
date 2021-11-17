using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUtensil : MonoBehaviour
{
    public GameObject itemOnCookingUtensil = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem()
    {
        Transform player = GameController.GetPlayer();
        GameObject veg = player.GetComponent<PlayerMovement>().GetItem();
        if (veg.GetComponent<Vegetables>() != null)
        {
            if (veg.GetComponent<Vegetables>().veggieState >= Vegetables.VegetablesState.fullyCut)
            {
                itemOnCookingUtensil = veg;
                veg.transform.parent = transform;
                veg.transform.localPosition = new Vector3(0, 0.3f, 0);
                player.GetComponent<PlayerMovement>().SetItem(null);
            }
        }

    }
}
