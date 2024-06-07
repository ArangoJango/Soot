using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript Instance;

    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManagerScript.StartListening("PlaySoundJump", PlaySoundJump);
        EventManagerScript.StartListening("PlaySoundLanding", PlaySoundLanding);
        EventManagerScript.StartListening("PlaySoundCollectCollectable", PlaySoundCollectCollectable);
        EventManagerScript.StartListening("PlaySoundCollectCoin", PlaySoundCollectCoin);
        EventManagerScript.StartListening("PlaySoundCheckpoint", PlaySoundCheckpoint);
        EventManagerScript.StartListening("PlaySoundFallingDeath", PlaySoundFallingDeath);
        EventManagerScript.StartListening("PlaySoundFallingWater", PlaySoundFallingWater);
        EventManagerScript.StartListening("PlaySoundLevelComplete", PlaySoundLevelComplete);
        EventManagerScript.StartListening("PlaySoundInteraction", PlaySoundInteraction);
        EventManagerScript.StartListening("PlaySoundEquip", PlaySoundEquip);
        EventManagerScript.StartListening("PlaySoundCountUp", PlaySoundCountUp);
        EventManagerScript.StartListening("PlaySoundBuy", PlaySoundBuy);
        EventManagerScript.StartListening("PlaySoundBoost", PlaySoundBoost);
    }

    private void OnDisable()
    {
        EventManagerScript.StopListening("PlaySoundJump", PlaySoundJump);
        EventManagerScript.StopListening("PlaySoundLanding", PlaySoundLanding);
        EventManagerScript.StopListening("PlaySoundCollectCollectable", PlaySoundCollectCollectable);
        EventManagerScript.StopListening("PlaySoundCollectCoin", PlaySoundCollectCoin);
        EventManagerScript.StopListening("PlaySoundCheckpoint", PlaySoundCheckpoint);
        EventManagerScript.StopListening("PlaySoundFallingDeath", PlaySoundFallingDeath);
        EventManagerScript.StopListening("PlaySoundFallingWater", PlaySoundFallingWater);
        EventManagerScript.StopListening("PlaySoundLevelComplete", PlaySoundLevelComplete);
        EventManagerScript.StopListening("PlaySoundInteraction", PlaySoundInteraction);
        EventManagerScript.StopListening("PlaySoundEquip", PlaySoundEquip);
        EventManagerScript.StopListening("PlaySoundCountUp", PlaySoundCountUp);
        EventManagerScript.StopListening("PlaySoundBuy", PlaySoundBuy);
        EventManagerScript.StopListening("PlaySoundBoost", PlaySoundBoost);
    }

    public void PlaySoundJump()
    {
        Debug.Log("PlaySoundJump triggered.");
        int randomInt = UnityEngine.Random.Range(0, 8);
        PlaySound(randomInt);
    }

    private void PlaySoundLanding()
    {
        int randomInt2 = UnityEngine.Random.Range(10, 17);
        PlaySound(randomInt2); 
    }
    private void PlaySoundCollectCollectable()
    {
        PlaySound(18); 
    }
    private void PlaySoundCollectCoin()
    {
        PlaySound(19);
    }
    private void PlaySoundCheckpoint()
    {
        PlaySound(20);
    }
    private void PlaySoundFallingDeath()
    {
        PlaySound(21);
    }
    private void PlaySoundFallingWater()
    {
        PlaySound(22);
    }
    private void PlaySoundLevelComplete()
    {
        PlaySound(23);
    }
    public void PlaySoundInteraction()
    {
        PlaySound(24);
    }
    private void PlaySoundEquip()
    {
        PlaySound(25);
    }
    private void PlaySoundCountUp()
    {
        PlaySound(26);
    }
    private void PlaySoundBuy()
    {
        PlaySound(27);
    }
    private void PlaySoundBoost()
    {
        PlaySound(28);
    }

    public void PlaySound(int index)
    {
            audioSource.clip = audioClips[index];
            audioSource.Play();
    }
}
