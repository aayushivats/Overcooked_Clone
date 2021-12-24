using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public int numPlayers = 1;
    public static GameController instance;
    public Transform playerPrefab;
    public List<Transform> players;
    public static bool startTimer=false;
    LevelManager levelManager;
    string[,] controls = new string[,] { {"PickupDropP1", "ChopP1", "HorizontalP1", "VerticalP1" },
    {"PickupDropP2", "ChopP2", "HorizontalP2", "VerticalP2" }};


    public int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        instance=this;
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if(numPlayers==1)
        {
            players.Add(Instantiate(playerPrefab).transform);
            players[0].GetComponent<PlayerMovement>().pickInput = controls[0, 0];
            players[0].GetComponent<PlayerMovement>().chopInput = controls[0, 1];
            players[0].GetComponent<PlayerMovement>().horizontalInput = controls[0, 2];
            players[0].GetComponent<PlayerMovement>().verticalInput = controls[0, 3];
            return;
        }

        for (int i = 0; i < numPlayers; i++)
        {
            players.Add(Instantiate(playerPrefab, LevelManager.instance.spawnPositions[i]).transform);
            players[i].GetComponent<PlayerMovement>().pickInput = controls[i, 0];
            players[i].GetComponent<PlayerMovement>().chopInput = controls[i, 1];
            players[i].GetComponent<PlayerMovement>().horizontalInput = controls[i, 2];
            players[i].GetComponent<PlayerMovement>().verticalInput = controls[i, 3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public static Transform GetPlayer(int playerIndex)
    {
        return instance.players[playerIndex];
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
       _score = score;
    }

    public void AddScore(int score)
    {
        _score += score;
        if(_score < 0)
        {
            _score = 0;
        }
    }
}
