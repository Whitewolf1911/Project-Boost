using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip landingSound;


    [SerializeField] float levelLoadDelay = 2f;

    bool isTransitioning = false;
    private void OnCollisionEnter(Collision other) {
        
        if(isTransitioning){return;} // in here if we are transitioning it will not do anything below this line ! 

        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Fuel":
                Debug.Log("FUEL TAKEN");
                break;

            case "Finish":
                NextLevelSequence();
                break;

            default:
                
                StartCrashSequence();       
                break;

        }
        
    }    

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartCrashSequence(){

        isTransitioning = true;
        Movement.audioSource.PlayOneShot(crashSound);   
        GetComponent<Movement>().enabled =false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void NextLevelSequence(){
        
        isTransitioning = true;
        Movement.audioSource.PlayOneShot(landingSound);
        GetComponent<Movement>().enabled =false;
        Invoke("LoadNextLevel", levelLoadDelay);
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

