using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using MyFps;

public class CinemachineShake : Singleton<CinemachineShake>
{
    #region Variables
    private CinemachineVirtualCamera cvCamera;
    private CinemachineBasicMultiChannelPerlin channelPerlin;

    private bool isShake = false;
    //[SerializeField] private float amplitued = 1f;      //Èçµé¸²ÀÇ Æø
    [SerializeField] private float frequency = 1f;      //Èçµé¸²ÀÇ ¼Óµµ
    #endregion

    protected override void Awake()
    {
        base.Awake();

        cvCamera = this.GetComponent<CinemachineVirtualCamera>();
        channelPerlin = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
       /* //cheating
        if(Input.GetKeyDown(KeyCode.G))
        {
            ShakeCamera(1f, 1f);
        }*/
    }

    //Ä«¸Þ¶ó Èçµé¸²
    //amplitued : Èçµé¸² ¼¼±â, Å©±â
    //shakeTime : Èçµé¸®´Â ½Ã°£
    public void ShakeCamera(float amplitued, float shakeTime)
    {
        if (isShake)
            return;

        StartCoroutine(StartShake(amplitued,shakeTime));
    }
    
    IEnumerator StartShake(float amplitued, float shakeTime)
    {
        isShake = true;
        channelPerlin.m_AmplitudeGain = amplitued;
        channelPerlin.m_FrequencyGain = frequency;

        yield return new WaitForSeconds(shakeTime);

        channelPerlin.m_AmplitudeGain = 0f;
        channelPerlin.m_FrequencyGain = 0f;

        isShake = false;
    }
}
