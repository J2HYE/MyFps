using UnityEngine;

namespace MyFps
{
    public enum Puzzlekey
    {
        ROOM01_KEY,   
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY         //���� ������ ����
    }

    //�÷��̾��� �Ӽ����� �����ϴ� (�̱���, DontDestroy)Ŭ����.. ammo
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        //SceneNumber
        private int sceneNumber;
        public int SceneNumber
        {
            get { return sceneNumber; }
            set { sceneNumber = value; }
        }
        //���� �÷����ϰ� �ִ� SceneNumber
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        //źȯ ����
        [SerializeField] private int ammoCount;
              
        public int AmmoCount
        {
            get { return ammoCount; }
            private set { ammoCount = value; }
        }

        //���� ���� ����
        private bool hasGun;
        public bool HasGun
        {
            get { return hasGun; }
            set
            {
                hasGun = value;
            }
        }

        //���� ���� ������
        private bool[] puzzleKeys;
        #endregion

        private void Start()
        {
            //�Ӽ���
            puzzleKeys = new bool[(int)Puzzlekey.MAX_KEY];
        }

        public void PlayerStatInit(PlayData playData)
        {
            if(playData != null)
            {
                SceneNumber = playData.sceneNumber;
                AmmoCount = playData.ammoCount;
                hasGun = playData.hasGun;
            }
            else //����� ������ ������
            {
                SceneNumber = 0;
                AmmoCount = 0;
                hasGun = false;
            }
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            //���� ���� üũ
            if(AmmoCount < amount)
            {
                Debug.Log("You need to reload!!!!");
                return false;
            }

            AmmoCount -= amount;
            return true;
        }

        //���� ������ ȹ��
        public void AcquirePuzzleItem(Puzzlekey key)
        {
            puzzleKeys[(int)key ] = true;
        }

        //���� ������ ���� ����
        public bool HasPuzzleItem(Puzzlekey key)
        {
            return puzzleKeys[(int)key];
        }

        //���� ����
        public void SetHasGun(bool value)
        {
            HasGun = value;
        }
    }
}