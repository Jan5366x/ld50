using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoncyScript : MonoBehaviour
{
    public float followRange = 12f;
    public float combatRange = 3f;
    public float speed = 500f;
    public float maxVelo = 5f;
    public float hitDelay =2f;
    public int hitDamage = 30;
    
    private GameObject _player;
    private Rigidbody2D _rb;
    private float combatDelay = 0.5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        var position = transform.position;
        var playerPos = _player.transform.position;
        bool inRange = Vector3.Distance(position, playerPos) <= followRange;
        bool inCombatRange = inRange && Vector3.Distance(position, playerPos) <= combatRange;
        
        Debug.DrawLine(position, playerPos, inCombatRange ? Color.red : inRange ? Color.green : Color.yellow);

        if (inCombatRange)
        {
            if (combatDelay > 0f) combatDelay -= Time.deltaTime;

            if (combatDelay <= 0)
            {
                _player.GetComponent<PlayerLifeScript>().Hit(hitDamage);
                combatDelay = hitDelay;
            }

        } else if (inRange && Mathf.Abs(_rb.velocity.x) < maxVelo)
        {
            _rb.AddForce(new Vector2(speed * Time.deltaTime * (transform.position.x > _player.transform.position.x ? -1f : 1f), 0f));
            combatDelay = 0.5f;
        }
    }
}
