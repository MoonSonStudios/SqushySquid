using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField]
    private int lives;
    public int maxLives = 5;
    public Vector3 startPos;
    private GameObject gameManager;
    public PlayerController pc;
    public Rigidbody2D rb;

    public Image[] hearts;
    private int currHeart = 4;

    public bool hadSecondChance = false;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        lives = maxLives;   
    }

    
    public void RemoveLife()
    {
        if(lives >= 1)
        {
            rb.transform.position = startPos;
            rb.velocity = Vector2.zero;
            gameManager.transform.rotation = Quaternion.identity;

            hearts[currHeart].enabled = false;
            currHeart--;
            lives--;

        }
        if(lives == 0)
        {
            GameOver();
        }
      

        
    }

    public void AddLife()
    {
        if(lives < maxLives)
        {
            hearts[currHeart + 1].enabled = true;
            currHeart++;
            lives++;
        }
    }

    public void SecondChance()
    {
        hearts[currHeart + 1].enabled = true;
        currHeart++;
        lives++;
        pc.SetDead(false);
        gameManager.GetComponent<GameManager>().ResumeGame();
    }

    private void GameOver()
    {
        pc.SetDead(true);
        gameManager.GetComponent<GameManager>().EndGame();
    }
}
