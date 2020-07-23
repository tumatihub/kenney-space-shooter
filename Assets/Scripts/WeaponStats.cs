using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponStats : ScriptableObject
{
    [SerializeField]
    float _laserSpeed = 10f;
    
    public float LaserSpeed { get => _laserSpeed; }
    [SerializeField]
    int _laserDelayLevel = 0;
    [SerializeField]
    float[] _laserDelays;

    [SerializeField]
    float _rocketDelay;
    public float RocketDelay { get => _rocketDelay; }

    [SerializeField]
    int _laserPowerLevel = 0;

    [Serializable]
    struct LaserPowerConfig
    {
        [SerializeField]
        int _numberOfSpawners;
        public int NumberOfSpawners { get => _numberOfSpawners; }
        [SerializeField]
        bool _useRocket;
        public bool UserRocket { get => _useRocket; }
    }
    [SerializeField]
    LaserPowerConfig[] _laserPowerList;

    public float GetLaserDelay()
    {
        return _laserDelays[_laserDelayLevel];
    }

    public int GetNumberOfLaserSpawners()
    {
        return _laserPowerList[_laserPowerLevel].NumberOfSpawners;
    }

    public bool IsUsingRocket()
    {
        return _laserPowerList[_laserPowerLevel].UserRocket;
    }
}
