using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDitector : MonoBehaviour
{
    [SerializeField] AudioClip drop;
    [SerializeField] AudioClip win;

    [SerializeField] ParticleSystem dropParticles;
    [SerializeField] ParticleSystem winParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }
        else
        {
            /*if (collision.gameObject.CompareTag("Ground"))
            {
                //isTransitioning = true;
                //DisableMoveScript();
                audioSource.PlayOneShot(drop);
            }*/
            if (collision.gameObject.CompareTag("NoZone"))
            {
                isTransitioning = true;
                DisableMoveScript();
                audioSource.PlayOneShot(drop);
                dropParticles.Play();
                levelManager.ReloadSequence();
            }
            else if (collision.gameObject.CompareTag("Finish"))
            {
                isTransitioning = true;
                DisableMoveScript();
                audioSource.PlayOneShot(win);
                winParticles.Play();
                levelManager.CurrentSceneIndex++;
                levelManager.ReloadSequence();
            }
        }
        

    }

    private void DisableMoveScript()
    {
        transform.GetComponent<PlayerMoveScript>().enabled = false;
    }

   /* void ReloadSequence()
    {
        Invoke("Reload", 2);
    }

    private void Reload()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }*/
}
