using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void ExitingApplication()
    {
        Application.Quit();
        Debug.Log("quit");

    }
}
