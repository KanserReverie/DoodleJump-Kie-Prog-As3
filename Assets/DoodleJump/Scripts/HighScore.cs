using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace doodleJump
{
    public class HighScore : MonoBehaviour
    {
        public Transform myPlayer;
        public Text myHighScoreText;
        public float myHighScore;

        // Start is called before the first frame update
        void Start()
        {
            myHighScore = 0;
        }

        // Just increases depending on time.
        // Your score is how long it takes for you to hit the end

        void LateUpdate()
        {
            myHighScore += Time.deltaTime;
            myHighScoreText.text = myHighScore.ToString("F1");
        }
    }
}