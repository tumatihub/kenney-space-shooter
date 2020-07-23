using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float _fireDelay = .2f;
    float _fireCountdown = 0f;
    const int _laserPoolSize = 50;
    Laser[] _laserPool = new Laser[_laserPoolSize];
    [SerializeField] Laser _laserPrefab;
    int _laserPoolIndex = 0;
    [SerializeField] float _laserVelocity = 1f;
    Transform _laserPoolParent;

    [SerializeField] Transform _centerLaserPosition;

    void Start()
    {
        _laserPoolParent = new GameObject("LaserPool").transform;
        InitializeLaserPool();
    }

    private void InitializeLaserPool()
    {
        for (int i = 0; i < _laserPool.Length; i++)
        {
            _laserPool[i] = Instantiate(_laserPrefab);
            _laserPool[i].gameObject.transform.parent = _laserPoolParent;
            _laserPool[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_fireCountdown <= 0f && Input.GetButton("Fire1"))
        {
            _laserPool[_laserPoolIndex].SetVelocity(_laserVelocity);
            _laserPool[_laserPoolIndex].transform.position = _centerLaserPosition.position;
            _laserPool[_laserPoolIndex].gameObject.SetActive(true);
            _fireCountdown = _fireDelay;
            _laserPoolIndex = _laserPoolIndex < _laserPool.Length - 1 ? _laserPoolIndex + 1 : 0;
        }
        else
        {
            _fireCountdown -= Time.deltaTime;
        }
    }
}
