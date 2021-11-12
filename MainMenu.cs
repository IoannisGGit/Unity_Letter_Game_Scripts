using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main menu and ui elements from https://www.youtube.com/watch?v=zc8ac_qUXQY
public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
