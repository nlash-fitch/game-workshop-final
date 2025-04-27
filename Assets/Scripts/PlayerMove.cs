using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public int spin;
    public GameObject PP;
    public int cooldown;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.right*Input.GetAxis("Horizontal")*speed*Time.deltaTime);
        transform.Rotate(-Vector3.forward * spin * Time.deltaTime * Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown("space") && cooldown<=0) {
            Instantiate(PP,this.transform.position,this.transform.rotation);
            cooldown = timer;
        }
    }

    void FixedUpdate()
    {
        if(cooldown > 0) {
            cooldown--;
        }
    }
}
