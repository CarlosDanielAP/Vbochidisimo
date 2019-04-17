using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palomascript : MonoBehaviour
{
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime+0.3f));

        if (transform.position.x <= -40)
        {
            Destroy(this.gameObject);
        }
    }
}
