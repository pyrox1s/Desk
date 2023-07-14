using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject _bullet;
    public Transform _shotPoint;

    private float _timeBtwShorts;
    public float _startTimeBtwShorts;


    void Update()
    {
        
        if(_timeBtwShorts <= 0)
        {
             if(Input.GetMouseButton(0))
             {
                 Instantiate(_bullet, _shotPoint.position, transform.rotation);
                _timeBtwShorts = _startTimeBtwShorts;
             }
 

        }
        else
        {
            _timeBtwShorts -= Time.deltaTime;
        }
    }
}
