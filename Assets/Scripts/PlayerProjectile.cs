using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int speed = 5;
    public GameObject me;
    public GameObject manager;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game manager");
        gameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (!gameManager.startGame) {
            Destroy(me);
        }
        if(this.transform.position.x < -20 || this.transform.position.x > 20 || this.transform.position.y < -20 || this.transform.position.y > 20) {
            Destroy(me);
        }
    }
}
