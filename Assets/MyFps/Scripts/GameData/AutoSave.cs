using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    //플레이씬이 시작하면 자동으로 게임 데이터 저장
    public class AutoSave : MonoBehaviour
    {
        private void Start ()
        {
            //
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            //현재 씬 저장
            int scenenumber = PlayerStats.Instance.SceneNumber;
            PlayerStats.Instance.NowSceneNumber = SceneManager.GetActiveScene().buildIndex;
            
           // Debug.Log($"{scenenumber}save number");
            //새로 플레이하는 씬이냐
            if (PlayerStats.Instance.NowSceneNumber > scenenumber)
            {
                PlayerPrefs.SetInt("PlayScene", PlayerStats.Instance.NowSceneNumber);
                SaveLoad.SaveData();

            }
        }
    }
}