using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    public float _lifetime;
    public float _distance;
    public int _damage;
    public GameObject _bulletEffect;

    public LayerMask whatIsSolid; //слой с пробиваемыми объектами



    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
               // hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);

            }       
            Instantiate(_bulletEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }

       
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject)
        {
            Destroy(gameObject);
            Instantiate(_bulletEffect, transform.position, Quaternion.identity);

        }
    }
}
