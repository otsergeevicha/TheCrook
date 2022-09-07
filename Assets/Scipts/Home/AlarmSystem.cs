using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AlarmSystem : MonoBehaviour
{
    [HideInInspector] private MeshRenderer _alarm;
    [HideInInspector] private AudioSource _audioAlarm;
    
    private float _maxVolume = 1;
    private float _rateStep = .1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _alarm = GetComponent<MeshRenderer>();
        _audioAlarm = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coroutine = StartCoroutine(WorkAlarm());
            _alarm.material.color = Color.red;
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(_coroutine);
            _alarm.material.color = Color.green;
            _audioAlarm.Stop();
        }
    }

    private IEnumerator WorkAlarm()
    {
        _audioAlarm.Play();

        while (_audioAlarm.volume != _maxVolume)
        {
            _audioAlarm.volume = Mathf.MoveTowards(_audioAlarm.volume, _maxVolume, _rateStep);
            yield return new WaitForSeconds(1f);
        }
    }
}
