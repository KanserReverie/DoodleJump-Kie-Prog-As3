using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace doodleJump
{
    public class LoadHighScores : MonoBehaviour
    {
        public HighScoreList highScoreList = new HighScoreList();
        public PlayerData lastScore;
        public Text displayHighScores;
        public Text displayLastScore;

        // Start is called before the first frame update
        void Start()
        {
            highScoreList = SaveSystem.LoadHighScoreList();
            lastScore = SaveSystem.LoadPlayer();

            highScoreList.myHighScoreList.OrderBy(PlayerData => PlayerData.PlayerScore);
            for (int i = 0; i < highScoreList.myHighScoreList.Count && i < 10; i++)
            {
                displayHighScores.text = (displayHighScores.text + highScoreList.myHighScoreList[i].PlayerName +" " + highScoreList.myHighScoreList[i].PlayerScore.ToString("F1") + "\n");
            }
            displayLastScore.text = ("Your Score = " + lastScore.PlayerName + " " + lastScore.PlayerScore.ToString("F1"));
        }


        public void ClearHighScores()
        {
            displayHighScores.text = "High Scores Reset";
            SaveSystem.ClearHighScoreList();

        }
    }
}