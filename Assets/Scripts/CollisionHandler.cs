using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Fuel":
                Debug.Log("FUEL TAKEN");
                break;

            case "Finish":
                LoadNextLevel();
                break;

            default:
                ReloadLevel();
                break;

        }
        
    }    

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        int nextSceneIndex = currentSceneIndex + 1 ;
        if(nextSceneIndex + 1 >  SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        } 
        SceneManager.LoadScene(nextSceneIndex);  
    }


}//class

