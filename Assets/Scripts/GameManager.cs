using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startGame;
    public int spawnTime;
    public GameObject target;
    public int count;
    public GameObject title;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (startGame) {
            if(count == spawnTime) {
                Instantiate(target, new Vector3(Random.Range(-8,8), 6, 0), Quaternion.identity);
                count = 0;
            } else {
                count++;
            }
        }
    }

    public void StartGame()
    {
        startGame = true;
        title.SetActive(false);
        Player.SetActive(true);
    }

    public void ResetGame()
    {
        startGame=false;
    }

    public void GameOver()
    {
        startGame = false;
        title.SetActive(true);
        count = 0;
        Player.SetActive(false);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        Player.transform.position = new Vector3(0, -4.5f, 0);
    }
}
