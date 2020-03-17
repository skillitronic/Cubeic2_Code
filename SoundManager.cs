using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private SaveSystem saveSystem;
    public AudioSource[] audioSources;
    public AudioClip[] sounds;
    public GameObject soundIcon;
    private void Awake()
    {
        saveSystem = GetComponent<SaveSystem>();
    }
    private void ChangeCondition(bool conditionBool)
    {
        for (int i = 0; i < audioSources.Length; i++)
            audioSources[i].enabled = conditionBool;
    }
    private void Start()
    {
        if (saveSystem.localSoundSwitched == true)
        {
            soundIcon.SetActive(true);
            ChangeCondition(false);
        }
        else
        {
            soundIcon.SetActive(false);
            ChangeCondition(true);
        }
        audioSources[1].clip = sounds[3];
    }

    public void PlayHitSound()
    {
        audioSources[0].clip = sounds[1];
        audioSources[0].Play();
    }
    public void PlayCollectedCoin()
    {
        audioSources[0].clip = sounds[0];
        audioSources[0].Play();
    }
    public void PlayWinSound()
    {
        audioSources[0].clip = sounds[2];
        audioSources[0].Play();
    }
    public void PlayWalkSound()
    {

        audioSources[1].Play();
    }
    public void StopWalkSound() {
        audioSources[1].Stop();
    }
    public void ToggleSound()
    {
        saveSystem.localSoundSwitched = !saveSystem.localSoundSwitched;
        if (saveSystem.localSoundSwitched == true)
        {
            soundIcon.SetActive(true);
            ChangeCondition(false);
        } else
        {
            soundIcon.SetActive(false);
            ChangeCondition(true);
        }
        saveSystem.SaveMusicSoundData();
    }

}
