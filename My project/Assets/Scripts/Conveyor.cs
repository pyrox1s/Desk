using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float speed, conveyorSpeed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private List<GameObject> onBelt;

    private Material material;

    private PlayerMove _playerMove;

    // Start is called before the first frame update
    void Start()
    {
        /* Create an instance of this texture
         * This should only be necessary if the belts are using the same material and are moving different speeds
         */
        material = GetComponent<MeshRenderer>().material;
        _playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Move the conveyor belt texture to make it look like it's moving
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    // Fixed update for physics
    void FixedUpdate()
    {
        // For every item on the belt, add force to it in the direction given
        for (int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
        }
    }

    // When something collides with the belt
    private void OnCollisionEnter(Collision coll)
    {
        onBelt.Add(coll.gameObject);
        //���������� ���� ���� �������
        if (coll.gameObject.CompareTag("Player"))
        {
            _playerMove.SlowSlip();
        }
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision coll)
    {
        onBelt.Remove(coll.gameObject);
        _playerMove.NormalWalk(); 
    }
}

