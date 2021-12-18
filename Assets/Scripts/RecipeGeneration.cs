using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGeneration : MonoBehaviour
{
    public static RecipeGeneration instance;
    List<RecipePanel> panels = new List<RecipePanel>();
    public GameObject panelPrefab;
    public Transform recipeHolder;
    public int maxPanelsOnScreen=5;
    public float panelDelay=10;
    private float timer=0;
    public int orderCount = 0;

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

        // Start is called before the first frame update
        void Start()
    {
        CreatePanel();
    }

    public List<RecipePanel> GetCurrentRecipes()
    {
        return panels;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(orderCount<LevelManager.instance.maxOrders && timer > panelDelay && panels.Count < maxPanelsOnScreen )
        {

            CreatePanel();
            timer = 0;
        }


    }

    public void DestroyPanel(RecipePanel recipePanel)
    {
        panels.Remove(recipePanel);
        DestroyImmediate(recipePanel.gameObject);
    }

    private void CreatePanel()
    {
      int rIndex = Random.Range(0, LevelManager.instance.recipesCookBook.Count);

      var go = Instantiate(panelPrefab, panelPrefab.transform.position + new Vector3(280 * panels.Count, 0, 0), panelPrefab.transform.rotation, recipeHolder);
      panels.Add(go.GetComponent<RecipePanel>());
      panels[panels.Count - 1].InitialisePanel(LevelManager.instance.recipesCookBook[rIndex]);
      go.SetActive(true);
        orderCount++;
    }
}
