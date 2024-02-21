using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AudioData : SerializableDictionary<string, AudioClip> { }
public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;
    public static AudioManager instance => Instance;

    [Header("бс AudioData")]
    public AudioData audioData;

    [Header("бс AudioSource")]
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        OnLoadStartScene("StartSceneBgm");
        SceneManager.sceneLoaded += OnLoadedSceneEvent;
    }

    public void OnLoadStartScene(string bgmName)
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
            return;

        audioSource.clip = audioData[bgmName];
        audioSource.Play();
        audioSource.loop = true;
    }

    public void OnLoadGameScene(string bgmName)
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
            return;

        audioSource.clip = audioData[bgmName];
        audioSource.Play();
        audioSource.loop = true;
    }

    public void StopBgm()
    {
        audioSource.Stop();
    }

    public void PlayBgm()
    {
        audioSource.Play();
    }

    public void OnLoadedSceneEvent(Scene scene,LoadSceneMode mode)
    {
        OnLoadGameScene("GameSceneBgm");
        OnLoadStartScene("StartSceneBgm");
    }

}
