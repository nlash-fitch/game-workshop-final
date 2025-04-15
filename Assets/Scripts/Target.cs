using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int speed = 5;
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down*Time.deltaTime*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(me);
    }
}
