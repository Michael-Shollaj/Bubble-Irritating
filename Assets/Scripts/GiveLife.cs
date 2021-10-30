using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLife : MonoBehaviour
{
    [SerializeField] private Vector2 _startForce;
    [SerializeField] private float _rapidFireInterval;

    private Rigidbody2D _rbd;

    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _rbd.AddForce(_startForce, ForceMode2D.Impulse);
    }
}
