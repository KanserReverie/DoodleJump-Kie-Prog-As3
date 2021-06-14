using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace doodleJump
{
    public class SettingsManager : MonoBehaviour
    {
        public GameObject SettingsPannel;
        public void CloseMenu()
        {
            Time.timeScale = 1;
            SettingsPannel.SetActive(false);
        }

    }
}