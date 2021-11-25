using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager :MonoBehaviour
{
    public static LevelManager instance;
    public int maxPlates;
    public int plates;
    float timer = 0;

    public GameObject platePrefab;
    public Transform plateStation;

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
    }


    public void ManagePlate()
    {
        
    }
}
