using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    private Image recipeImage;

    public Recipe panelRecipe;

    public Color cabbageColor = new Color(0.7538697f, 1.0f, 0.4591194f, 1.0f);
    public Color tomatoColor = new Color(0.8867924f, 0.02230917f, 0.02230917f, 1.0f);
    public Color cucumberColor = new Color(0.3208101f, 0.4528302f, 0.02847984f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialisePanel(Recipe recipe)
    {
        recipeImage = transform.GetChild(0).GetComponent<Image>();

        panelRecipe = recipe;
        switch (recipe._name)
        {
            case VegetableName.Cabbage:
                {
                    recipeImage.color = cabbageColor;
                    break;
                }
            case VegetableName.Tomato:
                {
                    recipeImage.color = tomatoColor;
                    break;
                }
            case VegetableName.Cucumber:
                {
                    recipeImage.color = cucumberColor;
                    break;
                }
            default: break;
        }
    }
}
