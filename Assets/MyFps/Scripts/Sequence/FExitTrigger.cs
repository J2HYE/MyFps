using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //���� 2���� Ŭ����
    public class FExitTrigger : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            PlaySequence();
        }

        void PlaySequence()
        {
            //�� Ŭ���� ó��
            //����� ����
            AudioManager.Instance.StopBgm();

            //���� �޴��� �̵�
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fader.FadeTo(loadToScene);
        }
    }
}