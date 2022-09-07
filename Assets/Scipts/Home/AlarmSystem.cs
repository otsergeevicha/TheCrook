using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [HideInInspector] private MeshRenderer _alarm;
    [HideInInspector] private AudioSource _alarmSound;
    [SerializeField] private Home _triggerHome;
    
    private float _maxVolume = 1;
    private float _rateStep = .1f;
    private float _volumeChangeTime = 1;
    private Coroutine _jobAlarm;

    private void Awake()
    {
        _alarm = GetComponent<MeshRenderer>();
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _triggerHome.Penetration += StartAlarm;
        _triggerHome.Leaving += StopAlarm;
    }

    private void OnDisable()
    {
        _triggerHome.Penetration -= StartAlarm;
        _triggerHome.Leaving -= StopAlarm;
    }
    
    private IEnumerator WorkAlarm()
    {
        _alarmSound.Play();
        var waitForSeconds = new WaitForSeconds(_volumeChangeTime);

        while (_alarmSound.volume != _maxVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _maxVolume, _rateStep);
            yield return waitForSeconds;
        }
    }
    
    private void StartAlarm()
    {
        _jobAlarm = StartCoroutine(WorkAlarm());
        _alarm.material.color = Color.red;
    }

    private void StopAlarm()
    {
        StopCoroutine(_jobAlarm);
        _alarmSound.volume = 0;
        _alarm.material.color = Color.green;
        _alarmSound.Stop();
    }
}