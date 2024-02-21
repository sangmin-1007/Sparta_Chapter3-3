using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData : SerializableDictionary<string, AudioClip> { }
public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance => instance;

    [Header("бс AudioData")]
    public AudioData audioData;

    [Header("бс AudioSource")]
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void OnPlayBGM(string bgmName)
    {
        audioSource.clip = audioData[bgmName];
        audioSource.Play();
        audioSource.loop = true;
    }

}
