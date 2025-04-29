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

    public int ammo = 5;

    public GameObject ammoC1;
    public GameObject ammoC2;
    public GameObject ammoC3;
    public GameObject ammoC4;
    public GameObject ammoC5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.right*Input.GetAxis("Horizontal")*speed*Time.deltaTime);
        transform.Rotate(-Vector3.forward * spin * Time.deltaTime * Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown("space") && ammo > 0) {
            Instantiate(PP,this.transform.position,this.transform.rotation);
            if (ammo == 5) {
                cooldown = timer;
            }
            ammo--;
            if (ammo == 4) {
                ammoC5.SetActive(false);
            } else if (ammo == 3) {
                ammoC4.SetActive(false);
            } else if (ammo == 2) {
                ammoC3.SetActive(false);
            } else if (ammo == 1) {
                ammoC2.SetActive(false);
            } else if (ammo == 0) {
                ammoC1.SetActive(false);
            }
        }
        
    }

    void FixedUpdate()
    {
        if(cooldown > 0 && ammo < 5) {
            cooldown--;
        }
        if (cooldown == 0 && ammo != 5) {
            ammo++;
            cooldown = timer;
            if(ammo == 5) {
                ammoC5.SetActive(true);
            }else if(ammo == 4) {
                ammoC4.SetActive(true);
            } else if (ammo == 3) {
                ammoC3.SetActive(true);
            } else if (ammo == 2) {
                ammoC2.SetActive(true);
            } else if (ammo == 1) {
                ammoC1.SetActive(true);
            }
        }
    }
}
