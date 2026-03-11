using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    
    AudioSource audioSource;

    bool isControllable = true;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
       if (!isControllable) { return; }
       
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
       isControllable = false;
        audioSource.Stop();
       audioSource.PlayOneShot(successSFX);
       successParticles.Play();
       GetComponent<Movement>().enabled = false;
       Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
       isControllable = false;
       audioSource.Stop();
       audioSource.PlayOneShot(crashSFX);
       crashParticles.Play();
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

