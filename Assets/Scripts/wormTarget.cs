using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormTarget : MonoBehaviour
{
    public int speed = 5;
    public GameObject me;
    public GameObject manager;
    public GameManager gameManager;
    public float maxDistance = 3;
    public float distance;
    public bool right=true;
    public bool right2 = true;
    public int dir = 3;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game manager");
        gameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(distance < maxDistance) {
            distance -= Vector3.down.y * Time.deltaTime * speed * 2;
            this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        } else if(dir>0 && dir<3) {
            this.transform.Rotate(new Vector3(0,0,90));
            distance = 0;
            right = false;
            dir += 1;
        } else if(dir>2 && dir<5) {
            this.transform.Rotate(new Vector3(0, 0, -90));
            distance = 0;
            right = true;
            dir += 1;
        } else {
            dir = 1;
        }
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (!gameManager.startGame) {
            Destroy(me);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(me);
        if (other.tag == "projectile") {
            gameManager.plusScore(10);
        }
    }
}
