using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;

        public GameObject optionUI;
        public GameObject mainMenuUI;
        public GameObject creditUI;
        public GameObject loadGameButton;

        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        //����Ǿ� �ִ� ����ȣ
        //private int sceneNumber;
        #endregion

        void Start ()
        {
            //���� ������ �ʱ�ȭ
            InitGameData();

            
            //����� �� ������
            if(PlayerStats.Instance.SceneNumber >0)
            {
                loadGameButton.SetActive(true);
            }

            //�� ���̵��� ȿ��
            fader.FromFade();

            //����
            audioManager = AudioManager.Instance;

            //Bgm �÷���
            audioManager.PlayBgm("MenuBgm");
        }

        private void InitGameData()
        {
            //���� ������, �ɼǰ� �ҷ�����
            LoadOptions();

            //���� �÷��� ������ �ε�
            PlayData playData = SaveLoad.LoadData();
            PlayerStats.Instance.PlayerStatInit(playData);
        }

        public void NewGame()
        {
            //���� ������ �ʱ�ȭ
            PlayerStats.Instance.PlayerStatInit(null);

            audioManager.Stop(audioManager.BgmSound);           
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(PlayerStats.Instance.SceneNumber);
        }

        public void Options()
        {
            audioManager.Play("MenuButton");

            ShowOptions();
        }

        public void Credits()
        {
            ShowCredits();
        }

        public void QuitGame()
        {
            //Cheating
            PlayerPrefs.DeleteAll();
            SaveLoad.DeleteFile();

            Debug.Log("Quit Game");
            Application.Quit();
        }

        private void ShowOptions()
        {
            audioManager.Play("MenuButton");

            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }

        public void HideOptions()
        {
            //�ɼǰ� �����ϱ�
            SaveOptions();

            mainMenuUI.SetActive(true);
            optionUI.SetActive(false);
        }

        //AudioMix Bgm -40~0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
        }

        //AudioMix Sfx -40~0
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        //�ɼǰ� �����ϱ�
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }

        //�ɼǰ� �ε��ϱ�
        private void LoadOptions()
        {
            //����� ���� ��������
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume",0);
            SetBgmVolume(bgmVolume);        //���� ���� ����
            bgmSlider.value = bgmVolume;    //UI����

            //ȿ���� ���� ��������
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetBgmVolume(sfxVolume);        //���� ���� ����
            sfxSlider.value = sfxVolume;    //UI����

            //��Ÿ...
        }

        private void ShowCredits()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }
    }
}