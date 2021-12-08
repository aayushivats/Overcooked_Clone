using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeGeneration : MonoBehaviour
{
    public GameObject recipePanel;
    public List<Material> recipeImages = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<5;i++)
        {
            Instantiate(recipePanel);
            
        }
    }
}
