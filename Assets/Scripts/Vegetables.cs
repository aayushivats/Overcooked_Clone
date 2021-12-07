using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public float timer;

    public bool startTimer = false;
    public enum VegetablesState
    {
        raw,
        partiallyCut,
        fullyCut,
        halfCooked,
        fullyCooked,
        burnt,
        Invalid
    };

    public VegetableName name;
    public VegetablesState veggieState = VegetablesState.raw;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer==true)
        {
            if (veggieState == VegetablesState.raw || veggieState==VegetablesState.partiallyCut)
            {
                veggieState = VegetablesState.partiallyCut;
                if (timer >= 2)
                {
                    startTimer = false;
                    timer = 0;
                    veggieState = VegetablesState.fullyCut;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);

                }
            }

            else if(veggieState==VegetablesState.fullyCut||veggieState==VegetablesState.halfCooked)
            {
                veggieState = VegetablesState.halfCooked;

            }
            timer += Time.deltaTime;

        }
    }

    void UpdateVegetableState(VegetablesState state)
    {
        veggieState = state;
    }
}
