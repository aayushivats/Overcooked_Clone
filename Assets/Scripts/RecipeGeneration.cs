using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGeneration : MonoBehaviour
{
    List<RecipePanel> panels = new List<RecipePanel>();
    public GameObject panelPrefab;
    public Transform recipeHolder;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            int rIndex = Random.Range(0, LevelManager.instance.recipesCookBook.Count);

            var go = Instantiate(panelPrefab, panelPrefab.transform.position + new Vector3(280 * i, 0, 0), panelPrefab.transform.rotation, recipeHolder);
            panels.Add(go.GetComponent<RecipePanel>());
            panels[panels.Count - 1].InitialisePanel(LevelManager.instance.recipesCookBook[rIndex]);

            go.SetActive(true);
        }
    }

    public List<RecipePanel> GetCurrentRecipes()
    {
        return panels;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
