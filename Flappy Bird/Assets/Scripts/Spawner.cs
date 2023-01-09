using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Pipe;
    private float yposition;
    private float spawnIntervals;
    [SerializeField]private float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= 2f)
        {
            spawnTimer = spawnIntervals;
            yposition = Random.Range(-2, 2);
            Vector3 randomspawn = new Vector3(8.5f, yposition, 0.0f);
            Instantiate(Pipe, randomspawn, Quaternion.identity);
            

        }
    }
}    