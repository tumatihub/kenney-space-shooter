using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Laser : MonoBehaviour
{

    float _velocity = 1f;
    float _lifeTime = 5f;
    public Transform PoolParent;
    bool _firstEnable = true;

    private void OnEnable()
    {
        if (_firstEnable)
        {
            _firstEnable = false;
        }
        else
        {
            Invoke("ReturnToPool", _lifeTime);
        }
    }

    void Update()
    {
        transform.Translate(_velocity * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool();    
    }

    public void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }

    private void ReturnToPool()
    {
        this.gameObject.SetActive(false);
    }
}
