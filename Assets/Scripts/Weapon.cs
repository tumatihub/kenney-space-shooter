using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float _fireCountdown = 0f;
    float _rocketCountdown = 0f;
    const int _laserPoolSize = 100;
    Laser[] _laserPool = new Laser[_laserPoolSize];
    [SerializeField] Laser _laserPrefab;
    int _laserPoolIndex = 0;
    Transform _laserPoolParent;

    [SerializeField] Transform[] _laserSpawners;
    [SerializeField] WeaponStats _weaponStats;

    void Start()
    {
        _laserPoolParent = new GameObject("LaserPool").transform;
        _weaponStats.RestartLevel();
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
        if (_weaponStats.IsUsingRocket())
        {
            ShootRocket();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DamagePowerUp":
                _weaponStats.LevelUpPower();
                break;
            case "FireRatePowerUp":
                _weaponStats.LevelUpLaserDelay();
                break;
            default:
                break;
        }
    }

    private void ShootRocket()
    {
        if (_rocketCountdown <= 0f && Input.GetButton("Fire1"))
        {

        }
        else
        {
            _rocketCountdown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (_fireCountdown <= 0f && Input.GetButton("Fire1"))
        {
            for (var i = 0; i < _weaponStats.GetNumberOfLaserSpawners(); i++)
            {
                _laserPool[_laserPoolIndex].SetVelocity(_weaponStats.LaserSpeed);
                _laserPool[_laserPoolIndex].transform.position = _laserSpawners[i].position;
                _laserPool[_laserPoolIndex].gameObject.SetActive(true);
                _fireCountdown = _weaponStats.GetLaserDelay();
                _laserPoolIndex = _laserPoolIndex < _laserPool.Length - 1 ? _laserPoolIndex + 1 : 0;
            }
        }
        else
        {
            _fireCountdown -= Time.deltaTime;
        }
    }
}
