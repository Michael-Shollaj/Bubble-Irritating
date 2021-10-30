using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _playerHit;
    [SerializeField] private AudioClip _powerUp;
    [SerializeField] private AudioClip _enemyHit;

    private AudioSource _audioSource;


    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        _audioSource.PlayOneShot(_shoot);
    }

    public void PlayerHit()
    {
        _audioSource.PlayOneShot(_playerHit);
    }

    public void PowerUp()
    {
        _audioSource.PlayOneShot(_powerUp);
    }

    public void EnemyHit()
    {
        _audioSource.PlayOneShot(_enemyHit);
    }
}
