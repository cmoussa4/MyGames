using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, startPos);
        if(dist > 20f)
        {
            Destroy(this.gameObject);
        }
        transform.position -= transform.right * movingSpeed * Time.deltaTime;
    }
}