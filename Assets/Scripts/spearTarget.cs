using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearTarget : MonoBehaviour
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
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (!gameManager.startGame) {
            Destroy(me);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(me);
        if (other.tag == "projectile") {
            gameManager.plusScore(5);
        }
    }
}
