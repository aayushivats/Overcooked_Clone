using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Recipe 
{
    VegetableName _name;
    Vegetables.VegetablesState _state;

    public Recipe(VegetableName name = VegetableName.Invalid, Vegetables.VegetablesState state = Vegetables.VegetablesState.Invalid)
    {
        _name = name;
        _state = state;
    }
}
