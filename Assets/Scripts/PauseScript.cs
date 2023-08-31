using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private void Start()
    {
        pauseScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        PauseMethod();

    }

    private void PauseMethod()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0.0f;
            pauseScreen.SetActive(true);
        }
    }
    public void ResumeMethod()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }
}
