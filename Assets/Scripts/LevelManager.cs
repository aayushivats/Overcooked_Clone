using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager :MonoBehaviour
{
    public static LevelManager instance;
    public int maxPlates;
    public int plates;
    float timer = 0;
    public float levelTimer = 120.0f;

    public GameObject platePrefab;
    public Transform plateStation;
    public TextMeshProUGUI levelTimerText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        plates = FindObjectsOfType<Plate>().Length;
        maxPlates = plates;
    }

    private void Update()
    {
        if(plates < maxPlates)
        {
            timer += Time.deltaTime;

            if(timer >= 2.0f)
            {
                plateStation.GetComponent<PlateStation>().platesOnStation++;
                plates++;
                GameObject tempPlate = Instantiate(platePrefab);
                plateStation.GetComponent<Station>().itemOnStation = tempPlate;
                tempPlate.transform.parent = plateStation;
                Debug.Log(plateStation.GetComponent<Collider>().bounds.max.y);
                tempPlate.transform.position = new Vector3(plateStation.position.x, plateStation.GetComponent<Collider>().bounds.max.y, plateStation.position.z);
                timer = 0;
            }
        }

        //Level timer
        levelTimer -= Time.deltaTime;
        int mins = (int)(levelTimer / 60.0f);
        int sec = (int)levelTimer - (mins * 60);
        levelTimerText.text = mins.ToString("00") + ":" + sec.ToString();

        if(levelTimer <= 0.0f)
        {
            Debug.Log("Game Over");
        }
    }


    public void ManagePlate()
    {
        
    }
}
