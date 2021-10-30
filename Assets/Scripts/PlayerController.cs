using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rbd;
    private bool _isGrounded;

    public static bool canFire;
    public static bool rapidFire;
    public static int score;
    public static int _lifeCount = 5;
    private bool m_FacingRight = true;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _chainPrefab;

    public Animator animator;


    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _isGrounded = false;
        canFire = true;
        rapidFire = false;
        score = 0;
    }

    void FixedUpdate()
    {
        Movement();


        if (CrossPlatformInputManager.GetButtonDown("Jump") && _rbd.velocity.y == 0)
            _rbd.AddForce(Vector2.up * 300);

        if (Input.GetButtonDown("Fire1") && _isGrounded && canFire)
        {
            Fire();
            AudioManager.Instance.Shoot();
            if (rapidFire)
            {
                canFire = true;
            }
            else
            {
                canFire = false;
            }
        }

        
    }


    // Movement and Jumping
    public void Movement()
    {
        _isGrounded = Grounded();

        float xMov = CrossPlatformInputManager.GetAxisRaw("Horizontal") * _speed;
        animator.SetFloat("speed",Mathf.Abs(xMov));

        if(xMov < 0 && m_FacingRight)
        {
            Flip();
        }
        if (xMov > 0 && !m_FacingRight)
        {
            Flip();
        }


        // Move the player
        _rbd.velocity = new Vector2(xMov * _speed, _rbd.velocity.y);
    }


    // For checking if grounded
    private bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .1f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * .1f, Color.green);

        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Jump()
    {
        _isGrounded = Grounded();

        if (CrossPlatformInputManager.GetButtonDown("Jump") && _isGrounded)
        {
            _rbd.velocity = new Vector2(_rbd.velocity.x, _jumpForce);
        }
    }

    // For fireing the chain / bulled
    public void Fire()
    {
        
        GameObject bullet = Instantiate(_chainPrefab, transform.position, Quaternion.identity) as GameObject;
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ball")
        {
            Damage();
            AudioManager.Instance.PlayerHit();

        }else if(other.collider.tag == "RapidFire")
        {
            AudioManager.Instance.PowerUp();
            other.collider.GetComponent<RapidFire>().StartRapidFire();
            other.collider.GetComponentInChildren<SpriteRenderer>().enabled = false;
            other.collider.enabled = false;
        }else if(other.collider.tag == "GiveLife")
        {
            _lifeCount++;
            AudioManager.Instance.PowerUp();
            Destroy(other.gameObject);
        }
       
    }

    public void Damage()
    {
        if (_lifeCount < 1)
            return;

        _lifeCount--;

        if (_lifeCount < 1) {
             GameManager.Instance.GameOver();
        }
       
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0);
    }
}
