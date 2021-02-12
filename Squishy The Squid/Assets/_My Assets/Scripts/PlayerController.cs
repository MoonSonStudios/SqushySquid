using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerProperties playerProps;
    private bool playerDead = false;

    [SerializeField]
    private float moveSpeed = 10;

    void Start()
    {
        playerDead = false;
        playerProps = GameObject.FindObjectOfType<PlayerProperties>();
        if (gameObject.GetComponent<Rigidbody2D>() != null)
            rb = gameObject.GetComponent<Rigidbody2D>();
        else gameObject.AddComponent<Rigidbody2D>();
            rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDead == false)
        {
            Vector2 moveDirection = rb.velocity;
            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(2);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(3);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(4);
            }

        }

    }
    public void SetDead(bool isDead)
    {
        playerDead = isDead;
    }

    public void Move(int direction)
    {
        //1 = up, 2 = down, 3 = left, 4 = right
        if (direction == 1)
        {
            rb.AddForce(new Vector2(0, moveSpeed));
        }
        else if(direction == 2)
        {
            rb.AddForce(new Vector2(0, -moveSpeed));
        }

        if(direction == 3)
        {
            rb.AddForce(new Vector2(-moveSpeed, 0));
        }
        else if(direction == 4)
        {
            rb.AddForce(new Vector2(moveSpeed, 0));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerDead == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                playerProps.RemoveLife();
            }
            else
            {
                if (collision.gameObject.tag == "LifeCoin")
                {
                    playerProps.AddLife();
                }
            }
        }
    }
}
