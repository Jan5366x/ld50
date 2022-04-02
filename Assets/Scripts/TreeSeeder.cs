using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeeder : MonoBehaviour
{
    public GameObject[] trees;
    public float maxSize = 1f;
    public float minSize = 0.7f;
    public float maxDistance = 2f;
    public float minDistance = 1f;
    public int amount = 50;


    
    // Start is called before the first frame update
    void Start()
    {
        var currentPos = 0f;
        GameObject last = null;
        for (int i = 0; i < amount; i++)
        {
            GameObject prefab;
            do
            {
                prefab = trees[Random.Range(0, trees.Length)];
            } while (trees.Length > 1 && last == prefab);
            
            
            var tree = Instantiate(prefab, transform);
            last = prefab;
            tree.transform.parent = transform;
            var size = Random.Range(minSize, maxSize);
            tree.transform.localPosition = new Vector3(currentPos += Random.Range(minDistance, maxDistance), 0f, 0f);
            tree.transform.localScale = new Vector3(size, size);
        }
    }
}
