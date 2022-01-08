using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other){
        switch (other.gameObject.tag){
            case "Obstacle":
                ReloadLevel();
            break;
            case "Finish": 
                Debug.Log("Hurray Completed!!");
                break;
        }
    }
    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // returns the index of current scene
    }
}
