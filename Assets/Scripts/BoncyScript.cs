using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoncyScript : MonoBehaviour
{
    public float followRange = 12f;
    public float combatRange = 3f;
    public float speed = 500f;
    public float maxVelo = 5f;
    
    private GameObject _player;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        bool inRange = Vector3.Distance(transform.position, _player.transform.position) <= followRange;
        bool inCombatRange = inRange && Vector3.Distance(transform.position, _player.transform.position) <= combatRange;
        Debug.DrawLine(transform.position, _player.transform.position, inCombatRange ? Color.red : inRange ? Color.green : Color.yellow);

        if (inCombatRange)
        {
            
        } else if (inRange && Mathf.Abs(_rb.velocity.x) < maxVelo)
        {
            _rb.AddForce(new Vector2(speed * Time.deltaTime * (transform.position.x > _player.transform.position.x ? -1f : 1f), 0f));
        }
    }
}
