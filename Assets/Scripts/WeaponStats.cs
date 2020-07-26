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
    public void RestartLevel()
    {
        _laserDelayLevel = 0;
        _laserPowerLevel = 0;
    }

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

    public void LevelUpLaserDelay()
    {
        _laserDelayLevel = Mathf.Min(_laserDelayLevel + 1, _laserDelays.Length - 1);
    }

    public void LevelDownLaserDelay()
    {
        _laserDelayLevel = Mathf.Max(_laserDelayLevel - 1, 0);
    }

    public void LevelUpPower()
    {
        _laserPowerLevel = Mathf.Min(_laserPowerLevel + 1, _laserPowerList.Length - 1);
    }

    public void LevelDownPower()
    {
        _laserPowerLevel = Mathf.Max(_laserPowerLevel - 1, 0);
    }
}
