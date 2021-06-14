using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doodleJump
{
    [System.Serializable]
    public class PlayerData
    {
        public string PlayerName;
        public float PlayerScore;

        public PlayerData(PlayerHS _PlayerHS)
        {
            PlayerName = _PlayerHS.Name;
            PlayerScore = _PlayerHS.Score;
        }
    }

    [System.Serializable]
    public class HighScoreList
    {
        public List<PlayerData> myHighScoreList = new List<PlayerData>();
    }
}