using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;

        private GameObject thePlayer;
        #endregion

        private void Start()
        {
            //ÂüÁ¶
            thePlayer = GameObject.Find("Player");
        }

        private void Update()
        {
            //
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf)
            {
                thePlayer.GetComponent<ThirdPersonController>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;
            }
            else
            {
                thePlayer.GetComponent<ThirdPersonController>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;
            }
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("Menu");
        }
    }
}