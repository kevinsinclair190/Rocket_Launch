using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    private void OnCollisionEnter(Collision other)
    {
       switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("All Good");
                break;
            case "Finish":
                StartSuccesSequence();
                break;
            default:
                StartCrashSequence();
                break;       
        }
    }    

    void StartSuccesSequence()
    {
       //add sfx and particles
       GetComponent<Movement>().enabled = false;
       Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
       //add sfx and particles
       GetComponent<Movement>().enabled = false;
       Invoke("ReloadLevel",levelLoadDelay);
    }

        void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    }

