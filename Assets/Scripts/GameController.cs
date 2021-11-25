using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform player;
    public static bool startTimer=false;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public static Transform GetPlayer()
    {
        return instance.player;
    }
}
