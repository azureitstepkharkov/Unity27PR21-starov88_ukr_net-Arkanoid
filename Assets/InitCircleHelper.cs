using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCircleHelper : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 21;
    public float radius = 60f;

    // Use this for initialization
    void Start ()
    {
        int block_counter = 0;
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
            block_counter++;
        }
        PlayerPrefs.SetInt("blocks_count", block_counter);
    }
	
}
