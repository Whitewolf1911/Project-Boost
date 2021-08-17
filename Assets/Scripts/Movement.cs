using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidB;
    AudioSource thrustSound;

    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        thrustSound= GetComponent<AudioSource>();

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
            if(!thrustSound.isPlaying){
            thrustSound.PlayOneShot(thrustSound.clip);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
            thrustSound.Stop();
        }
    }
    void ProcessRotation(){
        
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationPower);

        }

        else if(Input.GetKey(KeyCode.D)){

            ApplyRotation(-rotationPower);

        }

    }

    private void ApplyRotation(float rotationP)
    {
        rigidB.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationP );
        rigidB.freezeRotation = false; // unfreezing rotation so physics system can take over 
    }
}//class
