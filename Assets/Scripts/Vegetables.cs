using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public float cutTimer;

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

    public VegetableName _name;
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
                transform.GetComponentInParent<CuttingStation>().timerUI.gameObject.SetActive(true);
                transform.GetComponentInParent<CuttingStation>().timerUI.value = cutTimer / 2;
                veggieState = VegetablesState.partiallyCut;
                if (cutTimer >= 2)
                {
                    startTimer = false;
                    cutTimer = 0;
                    veggieState = VegetablesState.fullyCut;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetComponentInParent<CuttingStation>().timerUI.gameObject.SetActive(false);
                }
            }

            else if(veggieState==VegetablesState.fullyCut||veggieState==VegetablesState.halfCooked)
            {
                veggieState = VegetablesState.halfCooked;

            }
            cutTimer += Time.deltaTime;

        }
    }

    void UpdateVegetableState(VegetablesState state)
    {
        veggieState = state;
    }
}
