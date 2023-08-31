using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandlerScript : MonoBehaviour
{
    AudioSource audioSource;

    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    public void StartTheGame()
    {
        levelManager.CurrentSceneIndex++;
        levelManager.ReloadSequence();

    }
    public void ReStartTheGame()
    {
        levelManager.CurrentSceneIndex = 0;
        levelManager.ReloadSequence();

    }
}
