using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Utensil
{
    private void OnDestroy()
    {
        LevelManager.instance.plates--;
    }
}
 