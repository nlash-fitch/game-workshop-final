using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool startGame;
    public int spawnTime;
    public GameObject[] target;
    public int count;
    public GameObject title;
    public GameObject Player;
    public TextMeshProUGUI score;
    public int numScore;

    public AudioSource Audio;

    public int oldScore;
    public int life = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject lifeP;
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
                Instantiate(target[Random.Range(0,3)], new Vector3(Random.Range(-8,7), 6, 0), Quaternion.identity);
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
        score.text = "Score: " + numScore;
        lifeP.SetActive(false);
        life3.SetActive(true);
        life2.SetActive(true);
        life1.SetActive(true);
    }

    public void ResetGame()
    {
        startGame=false;
        numScore = 0;
        score.text = "Score: " + numScore;
    }

    public void GameOver()
    {
        startGame = false;
        title.SetActive(true);
        count = 0;
        Player.SendMessage("GameOver");
        Player.SetActive(false);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        Player.transform.position = new Vector3(0, -4.5f, 0);
        Player.transform.rotation = Quaternion.identity;
        numScore = 0;
        oldScore = 0;
        score.text = "Score: " + numScore;
        life = 3;
        spawnTime = 75;
    }

    public void plusScore(int toAdd)
    {
        numScore += toAdd;
        score.text = "Score: " + numScore;
        if (numScore-oldScore>=100) {
            updateLife(-1);
            oldScore = (numScore / 100) * 100;
            if(oldScore == 100) {
                spawnTime -= 10;
            }
            if(oldScore == 200) {
                spawnTime -= 10;
            }
            if(oldScore == 300) {
                spawnTime -= 5;
            }
            if(oldScore == 500) {
                spawnTime -= 5;
            }
            if(oldScore == 700) {
                spawnTime -= 5;
            }
        }
    }

    public void updateLife(int hurt)
    {
        life = life - hurt;


        if (life > 3) {
            lifeP.SetActive(true);
            life3.SetActive(true);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        if(life == 3) {
            lifeP.SetActive(false);
            life3.SetActive(true);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        if (life == 2) {
            lifeP.SetActive(false);
            life3.SetActive(false);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        if(life == 1) {
            lifeP.SetActive(false);
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(true);
        }
        if (life <= 0) {
            life = 0;
            lifeP.SetActive(false);
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
            GameOver();
        }

    }
}
