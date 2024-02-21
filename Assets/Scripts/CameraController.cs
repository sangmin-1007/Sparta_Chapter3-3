using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _targetPos;
    [SerializeField] private float _moveSpeed;

    private Camera _camera;
    // Start is called before the first frame update

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(_targetPos.position.x, _targetPos.position.y, _camera.transform.position.z);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position,playerPos, _moveSpeed * Time.deltaTime);
    }
}
