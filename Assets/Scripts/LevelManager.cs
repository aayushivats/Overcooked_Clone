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
    public RecipeGeneration recipeGenerator;
    public List<Recipe> recipesCookBook = new List<Recipe>();

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

        //Define recipes
        recipesCookBook.Add(new Recipe(VegetableName.Cucumber, Vegetables.VegetablesState.fullyCooked));
        recipesCookBook.Add(new Recipe(VegetableName.Tomato, Vegetables.VegetablesState.fullyCooked));
        recipesCookBook.Add(new Recipe(VegetableName.Cabbage, Vegetables.VegetablesState.fullyCooked));
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
        levelTimerText.text = mins.ToString("00") + ":" + sec.ToString("00");

        if(levelTimer <= 0.0f)
        {
            Debug.Log("Game Over");
        }
    }

    public bool IsValidRecipe(Recipe recipe)
    {
        foreach(var r in recipeGenerator.GetCurrentRecipes())
        {
            if(r.panelRecipe.Equals(recipe))
            {
                DestroyImmediate(r.gameObject);
                return true;
            }
        }
        return false;
    }
}
