using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform player;
    public static float timer;
    public static bool startTimer=false;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;

    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer==true)
        {
            timer += Time.deltaTime;
        }
        
    }

    public static Transform GetPlayer()
    {
        return instance.player;
    }
}
