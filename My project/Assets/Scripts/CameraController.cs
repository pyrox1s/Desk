using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _playerTransform;
    public Vector3 _offset;
    public float _camPositionSpeed = 5f;

    void LateUpdate()
    {
        Vector3 newCamPosition = new Vector3(_playerTransform.position.x + _offset.x, _playerTransform.position.y + _offset.y, _offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, _camPositionSpeed * Time.deltaTime);
    }
}