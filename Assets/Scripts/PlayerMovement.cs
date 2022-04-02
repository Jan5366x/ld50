using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 1500f;
    public float maxVelo = 6f;
    public float jumpPower = 10f;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var change = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_rb.velocity.x) < maxVelo)
        {
            _rb.AddForce(new Vector2(change * walkSpeed * Time.deltaTime, Input.GetButton("Jump") ? jumpPower : 0f));
        }
    }
}
