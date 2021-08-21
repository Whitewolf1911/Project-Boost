using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;

    [SerializeField] float period = 2f;

    
    void Start()
    {
        startingPosition = transform.position;    

    }

   
    void Update()
    {
        const float tau = Mathf.PI * 2; // we needed this because Sin takes argument as radiant constant value of 6.283
        if(period <= Mathf.Epsilon){return;} // to prevent NaN error we use this. mathf.epsilon is almost zero 
        // if you compare a float to zero use epsilon instead ! 

        float cycles = Time.time / period; // continually growing over time 
        float rawSinWave = Mathf.Sin(cycles * tau);    

        movementFactor = (rawSinWave + 1f) / 2f ; //changing -1 _ 1 to 0-1

        Vector3 offset = movementVector * movementFactor; 
        transform.position = startingPosition + offset;

    }
}
