using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace doodleJump
{
    // Called in Game to Submit highscore
    public class HighScoreSystem : MonoBehaviour
    {
        public HighScore myScore;

        public float myFinalScore;
        public string myName;

        public Text myFinalScoreText;

        // Update is called once per frame
        void Update()
        {
            myFinalScore = myScore.myHighScore;
            myFinalScoreText.text = myFinalScore.ToString("F1");
        }

        public void ReadStringInput(string s)
        {
            myName = s;
        }

        public void SubmitScore()
        {
            PlayerHS _PlayerHS = new PlayerHS();
            _PlayerHS.Name = myName;
            _PlayerHS.Score = myFinalScore;
            SaveSystem.SavePlayer(_PlayerHS);
            SaveSystem.SavePlayerToList(_PlayerHS);
            print("Player name Saving = " + _PlayerHS.Name);
            print("Player score Saving = " + _PlayerHS.Score);
            SceneManager.LoadScene(2);
        }
    }

    public class PlayerHS
    {
        public string Name;
        public float Score;
    }
}