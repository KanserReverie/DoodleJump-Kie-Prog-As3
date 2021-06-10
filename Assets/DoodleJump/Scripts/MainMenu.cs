using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace doodleJump
{
    public class MainMenu : MonoBehaviour
    {
        public void QuitButton()
        {
            Time.timeScale = 1;
            Application.Quit();
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        public void PlayButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
    }
}