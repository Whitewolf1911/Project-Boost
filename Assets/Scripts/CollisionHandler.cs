using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Fuel":
                
                break;

            case "Finish":
                
                break;

            default:

                break;

        }
        
    }    
}
