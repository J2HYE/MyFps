using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    //�÷��̾��� �����ϸ� �ڵ����� ���� ������ ����
    public class AutoSave : MonoBehaviour
    {
        private void Start ()
        {
            //
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            //���� �� ����
            int scenenumber = PlayerStats.Instance.SceneNumber;
            PlayerStats.Instance.NowSceneNumber = SceneManager.GetActiveScene().buildIndex;
            
           // Debug.Log($"{scenenumber}save number");
            //���� �÷����ϴ� ���̳�
            if (PlayerStats.Instance.NowSceneNumber > scenenumber)
            {
                PlayerPrefs.SetInt("PlayScene", PlayerStats.Instance.NowSceneNumber);
                SaveLoad.SaveData();

            }
        }
    }
}