using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxScript : MonoBehaviour
{
    public Transform[] frontLayer;
    public Transform[] backLayer;

    public float baseOffset = 0.001f;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (!_player)
            Debug.LogError("no player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (var i = 0; i < frontLayer.Length; i++)
        {
            var x = _player.transform.position.x * baseOffset * (i + 1);
            var pos = frontLayer[i].position;
            frontLayer[i].position = new Vector3(-x, frontLayer[i].position.y, frontLayer[i].position.z);
        }
        
        for (var i = 0; i < backLayer.Length; i++)
        {
            var x = _player.transform.position.x * baseOffset * (i + 1);
            var pos = backLayer[i].position;
            backLayer[i].position = new Vector3(x, backLayer[i].position.y, backLayer[i].position.z);
        }
    }
}
