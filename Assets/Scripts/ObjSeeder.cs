using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSeeder : MonoBehaviour
{
    public GameObject[] things;
    public float maxSize = 1f;
    public float minSize = 0.7f;
    public float maxDistance = 2f;
    public float minDistance = 1f;
    public int amount = 50;
    
    void Start()
    {
        var currentPos = 0f;
        GameObject last = null;
        for (int i = 0; i < amount; i++)
        {
            GameObject prefab;
            do
            {
                prefab = things[Random.Range(0, things.Length)];
            } while (things.Length > 1 && last == prefab);
            
            
            var obj = Instantiate(prefab, transform);
            last = prefab;
            obj.transform.parent = transform;
            var size = Random.Range(minSize, maxSize);
            obj.transform.localPosition = new Vector3(currentPos += Random.Range(minDistance, maxDistance), 0f, 0f);
            obj.transform.localScale = new Vector3(size, size);
        }
    }
}
