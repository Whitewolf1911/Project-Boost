using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isTransitioning = false;
    bool collisionDisable = false;

    private void Update() {
        
        RespondToDebugKeys();

    }
    private void OnCollisionEnter(Collision other) {
        
        if(isTransitioning || collisionDisable){return;} // in here if we are transitioning it will not do anything below this line ! 


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
        crashParticles.Play();
        isTransitioning = true;
        Movement.audioSource.PlayOneShot(crashSound);   
        GetComponent<Movement>().enabled =false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void NextLevelSequence(){
        successParticles.Play();
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

    void RespondToDebugKeys(){
        if(Input.GetKeyDown(KeyCode.L)){
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C)){
            collisionDisable = !collisionDisable; // toggle collision 
            Debug.Log("Collision disabled / enabled. ");
        }
    }


}//class

