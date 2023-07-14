using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchBox : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerBody;


    [SerializeField] private Vector3 _scaleDown = new Vector3(1.2f, 0.8f, 1.2f);
    [SerializeField] private Vector3 _scaleUp = new Vector3(0.8f, 1.2f, 0.8f);

    [SerializeField] private float _scaleKoefficient;
    [SerializeField] private float _rotateKoefficient;

    void Update()
    {
        Vector3 relativePosition = _playerTransform.InverseTransformPoint(transform.position);
        float interpolant = relativePosition.y * _scaleKoefficient;
        Vector3 scale = Lerp3(_scaleDown, Vector3.one, _scaleUp, interpolant);
        _playerBody.localScale = scale;
        _playerBody.localEulerAngles = new Vector3(relativePosition.z, 0, -relativePosition.x) * _rotateKoefficient;
        
    }


    Vector3 Lerp3(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        if (t < 0)
            return Vector3.Lerp(a, b, t + 1f);
        else
            return Vector3.Lerp(b, c, t);
    }

   
    
}

