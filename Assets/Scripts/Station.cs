using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Station : MonoBehaviour
{
    
    public GameObject itemOnStation = null;

    public bool isOccupied
    { get { return itemOnStation != null; } }

    public virtual bool DoPickupDrop(Transform player)
    {
        Debug.Log("No Action Defined");
        return false;
    }

    public virtual bool DoChop(Transform player)
    {
        Debug.Log("No Action Defined");
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
