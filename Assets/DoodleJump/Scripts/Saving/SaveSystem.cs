using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

namespace doodleJump
{
    public static class SaveSystem
    {
        public static void SavePlayer(PlayerHS _player)
        {
            Debug.Log("Saving Player " + _player.Name + " " + _player.Score);

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/LastPlayer.hss";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(_player);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        // Save the last score to the list.
        public static void SavePlayerToList(PlayerHS _player)
        {
            Debug.Log("Saving to HS list " +_player.Name + " " + _player.Score);
            string path = Application.persistentDataPath + "/playerHSList.hss";

            // If the File doesn't exist make a new one with this name ane with a class "HighScoreList"
            if (!File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                HighScoreList HSdata = new HighScoreList();
                formatter.Serialize(stream, HSdata);
                stream.Close();
            }

            // Getting the list and adding a new score to it.
            BinaryFormatter formatter2 = new BinaryFormatter();
            FileStream stream2 = new FileStream(path, FileMode.Open);
            
            // We are making a new HighScore List.
            HighScoreList data = new HighScoreList();

            // We are then making a new entery to add to this list.
            PlayerData data3 = new PlayerData(_player);
            

            data = formatter2.Deserialize(stream2) as HighScoreList;

            // We will then close this list so that we can now add to it.
            stream2.Close();

            // We will then add to this list.
            data.myHighScoreList.Add(data3);

            // We are now opening this for the last time to add to the list again.
            BinaryFormatter formatter3 = new BinaryFormatter();
            FileStream stream3 = new FileStream(path, FileMode.Open);


            // Saves and closes it.
            formatter2.Serialize(stream3, data);

            stream2.Close();
        }

        // This it to load the last score
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/LastPlayer.hss";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                Debug.Log("Loading Player " + data.PlayerName + " " + data.PlayerScore);

                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }

        }

        // Opens all the highscores in a list.
        public static HighScoreList LoadHighScoreList()
        {
            // 1. Opens a highscore list
            Debug.Log("Loading High Score List");
            string path = Application.persistentDataPath + "/playerHSList.hss";
            if (File.Exists(path))
            {

                // Sends back the data as "HighScoreList".
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                HighScoreList data = formatter.Deserialize(stream) as HighScoreList;
                stream.Close();

                for (int i = 0; i < data.myHighScoreList.Count; i++)
                {
                    Debug.Log("Loading Player " + data.myHighScoreList[i].PlayerName + " " + data.myHighScoreList[i].PlayerScore + " from<HighScoreList>");
                }

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
        // Opens all the highscores in a list.
        public static void ClearHighScoreList()
        {
            // 1. Opens a highscore list
            string path = Application.persistentDataPath + "/playerHSList.hss";
            if (File.Exists(path))
            {
                // OverWrites the old HS with a new one.
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                HighScoreList HSdata = new HighScoreList();
                formatter.Serialize(stream, HSdata);
                stream.Close();
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
            }
        }
    }
}