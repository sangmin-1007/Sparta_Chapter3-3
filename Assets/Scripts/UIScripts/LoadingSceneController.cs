using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [Header("бс Image")]
    [SerializeField] private Image loadingBar;

    [Header("бс Text")]
    [SerializeField] private string[] tip;
    [SerializeField] private TextMeshProUGUI tipText;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        AudioManager.instance.StopBgm();
        SceneManager.LoadScene("LoadScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
        int randomIndex = UnityEngine.Random.Range(0, tip.Length);
        tipText.text = tip[randomIndex];
    }


    private IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                loadingBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer * 0.5f);
                if (loadingBar.fillAmount >= 1f)
                {
                    if (nextScene == "GameScene")
                        op.completed += GameManager.instance.AsyncOperationCompletedEvent;

                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
