using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("бс Option")]
    [SerializeField] private float _moveSpeed;

    private Camera _camera;
    private Transform _targetPos;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _targetPos = GameManager.instance.playerPrefab.transform;
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(_targetPos.position.x, _targetPos.position.y, _camera.transform.position.z);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position,playerPos, _moveSpeed * Time.deltaTime);
    }
}
