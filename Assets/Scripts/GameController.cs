using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VegetableName
{
    Tomato,
    Cucumber,
    Cabbage,
    Invalid
};

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

    public int GetScore()
    {
        return player.GetComponent<PlayerMovement>().score;
    }

    public void SetScore(int score)
    {
       player.GetComponent<PlayerMovement>().score = score;
    }

    public void AddScore(int score)
    {
        player.GetComponent<PlayerMovement>().score += score;
        if(player.GetComponent<PlayerMovement>().score < 0)
        {
            player.GetComponent<PlayerMovement>().score = 0;
        }
    }
}
