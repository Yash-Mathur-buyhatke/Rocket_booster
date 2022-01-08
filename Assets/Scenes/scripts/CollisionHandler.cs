using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other){
        switch (other.gameObject.tag){
            case "Fuel":
                Debug.Log("Phew thanks for fuel!!");
                break;
            case "Obstacle":
                GetComponent<RocketMovement>().enabled = false;     // taking controls from user to operate rocket
                Invoke("ReloadLevel",1f);   // Invoke calls a function after specified amount of time
                break;
            case "Finish": 
                Debug.Log("Hurray Completed!!");
                GetComponent<RocketMovement>().enabled = false;     // taking controls from user to operate rocket
                Invoke("NextLevel",1f); // 1f denotes after 1 sec this NextLevel function will be called
                break;
            
        }
    }
    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // returns the index of current scene
        GetComponent<RocketMovement>().enabled = true;      // giving controls to user to operate rocket
    }
    void NextLevel(){
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex+1;
        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings){
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex); // returns the index of current scene
        GetComponent<RocketMovement>().enabled = true;      // giving controls to user to operate rocket
    }
}
