using UnityEngine;
using UnityEngine.Audio;

namespace MyFps
{
    //������� �����ϴ� Ŭ����
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        #region Variables
        public Sound[] sounds;
        private string bgmSound = "";       //���� �÷��� �Ǵ� �����
        public string BgmSound
        {
            get { return bgmSound; }
        }

        //Audio
        public AudioMixer audioMixer;
        #endregion

        protected override void Awake()
        {
            //Singletone ������
            base.Awake();

            //AudioMixer
            AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups("Master");

            //AudioManager�ʱ�ȭ
            foreach(var sound in sounds)
            {
                sound.source = this.gameObject.AddComponent<AudioSource>();

                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;

                if (sound.loop)
                {
                    sound.source.outputAudioMixerGroup = audioMixerGroups[1];   //Bgm
                }
                else
                {
                    sound.source.outputAudioMixerGroup = audioMixerGroups[2];   //Sfx
                }
            }
        }
        
        public void Play(string name)
        {
            Sound sound = null;

            //�Ű����� �̸��� ���� Ŭ�� ã��
            foreach(var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;
                    break;
                }
            }

            //���� Ŭ���� ������
            if(sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;

            //�Ű����� �̸��� ���� Ŭ�� ã��
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;

                    //
                    if(s.name == name)
                    {
                        bgmSound = "";
                    }
                    break;
                }
            }

            //���� Ŭ���� ������
            if (sound == null)
            {
                //Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Stop();
        }

        //����� ���
        public void PlayBgm(string name)
        {
            //����� �̸� üũ
            if(bgmSound == name)
            {
                return;
            }

            //����� ����
            StopBgm();

            Sound sound = null;

            foreach(var s in sounds)
            {
                if(s.name == name)
                {
                    bgmSound = s.name;
                    sound = s;
                    break ;
                }
            }

            //�Ű����� �̸��� ���� Ŭ���� ������
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Play();
        }

        public void StopBgm()
        {
            Stop(bgmSound);
        }
    }
}