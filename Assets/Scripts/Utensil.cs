using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utensil : MonoBehaviour
{

    public GameObject itemInUtensil;

    public void AddItem(Transform player)
    {
        GameObject veg = player.GetComponent<PlayerMovement>().GetItem();
        if (veg.GetComponent<Vegetables>() != null)
        {
            if (veg.GetComponent<Vegetables>().veggieState >= Vegetables.VegetablesState.fullyCut)
            {
                itemInUtensil = veg;
                veg.transform.parent = transform;
                veg.transform.localPosition = new Vector3(0, 0.3f, 0);
                player.GetComponent<PlayerMovement>().SetItem(null);
            }
        }
    }

    public bool AddItem(GameObject veg)
    {
        if (itemInUtensil == null)
        {
            itemInUtensil = veg;
            veg.transform.parent = transform;
            veg.transform.localPosition = new Vector3(0, 0.3f, 0);
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
