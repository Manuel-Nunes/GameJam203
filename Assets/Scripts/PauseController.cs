using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
