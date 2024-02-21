using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public static GameManager instance => Instance;

    [HideInInspector]public GameObject playerPrefab;

    private List<Vector3> randomSpawnPoint = new List<Vector3>();
    private void Awake()
    {
        if(Instance == null)
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
        //SceneManager.sceneLoaded += OnLoadedSceneEvent;
    }

    private void InstantiatePlayer()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
            return;

        SpawnPosSpecify();
        
        playerPrefab = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));

        int randomIndex = Random.Range(0, randomSpawnPoint.Count);

        playerPrefab.transform.position = randomSpawnPoint[randomIndex];
    }

    private void SpawnPosSpecify()
    {
        randomSpawnPoint.Add(new Vector3(0f,0f,0f));
        randomSpawnPoint.Add(new Vector3(34f,-10f,0f));
    }

    public void AsyncOperationCompletedEvent(AsyncOperation op)
    {
        InstantiatePlayer();
    }

}
