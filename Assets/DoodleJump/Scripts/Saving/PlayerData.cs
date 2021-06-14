using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace doodleJump
{
    [System.Serializable]
    // Player Data to save and load
    public class PlayerData : IComparable<PlayerData>
    {
        public string PlayerName;
        public float PlayerScore;

        public PlayerData(PlayerHS _PlayerHS)
        {
            PlayerName = _PlayerHS.Name;
            PlayerScore = _PlayerHS.Score;
        }

        // This will give us the smallest one first.
        public int CompareTo(PlayerData _Player)
        {
            if (_Player == null)
            {
                return 1;
            }
            float x1 = PlayerScore * 100;
            int x2 = (int)x1;

            float y1 =_Player.PlayerScore * 100;
            int y2 = (int)y1;
            return x2 - y2;
        }
    }

    [System.Serializable]
    // List of all the HighScores to display.
    public class HighScoreList
    {
        public List<PlayerData> myHighScoreList = new List<PlayerData>();
    }
}