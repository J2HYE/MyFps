using UnityEngine;

namespace MyFps
{
    //���Ͽ� ������ ���� �÷��� ������ ���
    [System.Serializable]
    public class PlayData
    {
        public int sceneNumber;
        public int ammoCount;
        public bool hasGun;

        //������ - Playerstats�� �ִ� �����ͷ� �ʱ�ȭ
        public PlayData()
        {
            sceneNumber = PlayerStats.Instance.SceneNumber;
            ammoCount = PlayerStats.Instance.AmmoCount;
            hasGun = PlayerStats.Instance.HasGun;
        }
    }
}
