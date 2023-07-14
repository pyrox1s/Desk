using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Transform _centerOfMassTransform;
    private void Awake()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.Scale(_centerOfMassTransform.localPosition, transform.localScale);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    }
}
