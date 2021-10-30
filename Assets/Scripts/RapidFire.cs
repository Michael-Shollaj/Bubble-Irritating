using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    [SerializeField] private Vector2 _startForce;
    [SerializeField] private float _rapidFireInterval;

    private Rigidbody2D _rbd;

    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _rbd.AddForce(_startForce, ForceMode2D.Impulse);
    }

   
    public void StartRapidFire()
    {
        StartCoroutine(RapidFireCoroutine());
    }

    IEnumerator RapidFireCoroutine()
    {

        PlayerController.rapidFire = true;
        yield return new WaitForSeconds(_rapidFireInterval);
        PlayerController.rapidFire = false;
        Destroy(gameObject);
    }
}
