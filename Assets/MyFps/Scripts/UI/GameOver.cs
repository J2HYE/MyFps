using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string loadToScene = "PlayScene";
        #endregion

        private void Start()
        {
            //���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //���̵��� ȿ��
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(PlayerStats.Instance.NowSceneNumber);
        }

        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}
