using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 1500f;
    public float maxVelo = 6f;
    public float jumpPower = 10f;

    private Rigidbody2D _rb;
    private Animator _ani;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var change = Input.GetAxis("Horizontal");
        var absVelo = Mathf.Abs(_rb.velocity.x);
        var dirRight = _rb.velocity.x >= 0;
        Debug.Log(_rb.velocity.x);
        if (absVelo < maxVelo)
        {
            _rb.AddForce(new Vector2(change * walkSpeed * Time.deltaTime, Input.GetButton("Jump") ? jumpPower : 0f));
        }
        
        _ani.SetBool("walk",absVelo > 0.5f);

       
        gameObject.transform.localScale = new Vector3(dirRight ? 1f : -1f,1f,1f );
        
    }
}
