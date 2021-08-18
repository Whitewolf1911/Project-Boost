using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidB;
    public static AudioSource audioSource;
    [SerializeField]  AudioClip engineThrust;
    [SerializeField]  AudioClip sideThrustAudio;

    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 50f;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem leftBooster;


    bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust(){

        if(Input.GetKey(KeyCode.Space)){
            
            rigidB.AddRelativeForce(Vector3.up * Time.deltaTime * thrustPower);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(engineThrust);

            }
            if(!mainBooster.isPlaying){
                mainBooster.Play();
            }
        }
        else {
            //Stop Thrusting
            audioSource.Stop();
            mainBooster.Stop();
        }
    }
    void ProcessRotation(){
        //processing left and right rotation
        if(Input.GetKey(KeyCode.A))
        {   
            ApplyRotation(rotationPower);
            if(!rightBooster.isPlaying){
                rightBooster.Play();
            }

        }
    
        else if(Input.GetKey(KeyCode.D)){

            ApplyRotation(-rotationPower);
            if(!leftBooster.isPlaying){
                leftBooster.Play();
            }
        }

        else{
            //Stop Thrusting
            rightBooster.Stop();
            leftBooster.Stop();
           
        }

    }

    private void ApplyRotation(float rotationP)
    {
        rigidB.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationP );
        rigidB.freezeRotation = false; // unfreezing rotation so physics system can take over 
        // you did this because when collision happens controls got bugged . this way it doesn't !!
    }

}//class
