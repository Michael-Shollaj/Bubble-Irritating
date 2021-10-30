using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _rapidFire;
    [SerializeField] private GameObject _giveLife;

    public float _spawnDelay;


    private void Start()
    {
        InvokeRepeating("PowerUpSpawner", _spawnDelay, _spawnDelay);
    }

    private void PowerUpSpawner()
    {
        if (GameManager.Instance._continueScreen.activeSelf || GameManager.Instance._gameOverScreen.activeSelf) {
            return;
        }

            GameObject prefab = RandomSpawn();
        if(prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    private GameObject RandomSpawn()
    {
        int index = Random.Range(1, 3);

        switch (index)
        {
            case 1:
                return _rapidFire;
                break;
            case 2:
                return _giveLife;
                break;
            default:
                return null;
                break;
        }
    }
}
