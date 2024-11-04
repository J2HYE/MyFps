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
    //[SerializeField] private float amplitued = 1f;      //��鸲�� ��
    [SerializeField] private float frequency = 1f;      //��鸲�� �ӵ�
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

    //ī�޶� ��鸲
    //amplitued : ��鸲 ����, ũ��
    //shakeTime : ��鸮�� �ð�
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
