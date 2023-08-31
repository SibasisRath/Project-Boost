using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    public int CurrentSceneIndex { get => currentSceneIndex; set => currentSceneIndex = value; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadSequence()
    {
        Invoke("Reload", 2);
    }

    private void Reload()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
