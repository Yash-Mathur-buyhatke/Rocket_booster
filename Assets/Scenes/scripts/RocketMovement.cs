using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float mainThrust;
    [SerializeField] float thrustPower;

    [SerializeField] ParticleSystem thrustParticles;
    [SerializeField] ParticleSystem leftWingParticles;
    [SerializeField] ParticleSystem rightWingParticles;


    Rigidbody rigidbody;
    AudioSource audio;
    [SerializeField] AudioClip thrustAudio;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainThrust = 800f;
        thrustPower = 60f;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(thrustAudio);
            }
            if (!thrustParticles.isPlaying)
            {
                thrustParticles.Play();

            }
            if (!leftWingParticles.isPlaying)
            {
                leftWingParticles.Play();

            }
            if (!rightWingParticles.isPlaying)
            {
                rightWingParticles.Play();

        }
        }
        else
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
            if (thrustParticles.isPlaying)
            {
                thrustParticles.Stop();

            }
            if (leftWingParticles.isPlaying)
            {
                leftWingParticles.Stop();

            }
            if (rightWingParticles.isPlaying)
            {
                rightWingParticles.Stop();

            }
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating to Left");
            // rigidbody.freezeRotation = true;
            transform.Rotate(Vector3.forward * thrustPower * Time.deltaTime); // denotes (0,0,1)
            // rigidbody.freezeRotation = false;

        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating to Right");
            // rigidbody.freezeRotation = true;
            transform.Rotate(-Vector3.forward * thrustPower * Time.deltaTime); // denotes (0,0,-1)
            // rigidbody.freezeRotation = true;
        }
    }
}
