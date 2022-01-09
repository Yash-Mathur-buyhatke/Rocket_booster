using System.Collections;
//through reflection
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    AudioSource audio;

    [SerializeField] bool isAlive = true;

    [SerializeField] AudioClip collisionAudio;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip levelCompleteAudio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if(isAlive){
            switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Phew thanks for fuel!!");
                break;
            case "Obstacle":
                GetComponent<RocketMovement>().enabled = false;

                if (audio.isPlaying)
                {
                    audio.Stop();
                    audio.PlayOneShot(collisionAudio);

                }
                else
                {
                    audio.PlayOneShot(collisionAudio);
                }  // taking controls from user to operate rocket
                isAlive = false;
                Invoke("ReloadLevel", 3f);   // Invoke calls a function after specified amount of time
                break;
            case "Finish":
                Debug.Log("Hurray Completed!!");
                GetComponent<RocketMovement>().enabled = false;
                isAlive = false;
                successParticles.Play();
                if (audio.isPlaying)
                {
                    audio.Stop();
                    audio.PlayOneShot(levelCompleteAudio);
                }
                else
                {
                    audio.PlayOneShot(levelCompleteAudio);   // taking controls from user to operate rocket
                    
                }
                Invoke("NextLevel", 1f); // 1f denotes after 1 sec this NextLevel function will be called
                break;


        }
        }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // returns the index of current scene
        GetComponent<RocketMovement>().enabled = true;      // giving controls to user to operate rocket
    }
    void NextLevel()
    {
        successParticles.Stop();
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex); // returns the index of current scene
        GetComponent<RocketMovement>().enabled = true;      // giving controls to user to operate rocket
    }
}
