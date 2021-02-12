using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraRig;

    public GameObject levelGate;

    public Transform[] startPostions;
    
    public GameObject startRoom;
    public GameObject endRoom;

    public GameObject[] rooms; //i = 0 --> LR, i = 1 --> LRD, i = 2 --> LRU, i = 3 --> LRUD, i = 4 endRoom

    private int direction;
    public int moveAmount = 10;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.0001f;

    public float minX;
    public float maxX;
    public float minY;

    public bool stopGen;

    public LayerMask room;

    private int downCounter;

    private PlayerProperties playerProps;

    private void Start()
    {
        playerProps = GameObject.FindObjectOfType<PlayerProperties>();
    }
    private void Update()
    {
        if(timeBtwRoom <= 0 && stopGen == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }
    public void CreateNewLevel()
    {
        //ClearLevel();
        CreateLevel();
        
       
    }

    private void ClearLevel()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("MasterRoom");
        if(rooms != null)
        {
            foreach(GameObject room in rooms)
            {
                Destroy(room);
            }
        }
    }
    private void CreateLevel()
    {

        stopGen = false;
        int randomStartPos = Random.Range(0, startPostions.Length);
        transform.position = startPostions[randomStartPos].position;

        Instantiate(startRoom, transform.position, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        playerProps.startPos = transform.position;
        player.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z);
        PlayerProperties playerProp = GameObject.FindObjectOfType<PlayerProperties>();
        playerProp.rb = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInParent<Rigidbody2D>();
        Instantiate(cameraRig, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Move()
    {
        if (direction == 1 || direction == 2)//Move Right
        {
            
            if (transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 3 || direction == 4)//Move Left
        {
            
            if (transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);

            }
            else
            {
                direction = 5;
            }
           
        }
        else if (direction == 5)//Move Down
        {

            downCounter++;

            if(transform.position.y > minY)
            {

                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if(roomDetection.GetComponent<RoomType>().Type != 1 && roomDetection.GetComponent<RoomType>().Type != 3)
                {
                    if(downCounter>= 2)
                    {
                        roomDetection.GetComponent<RoomType>().DestroyRoom();
                        Instantiate(rooms[3], transform.position,Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().DestroyRoom();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }

                    
                }

                Vector2 newPos = new Vector2(transform.position.x , transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
               
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomType>() != null )
                {
                    Debug.Log("Spawning end room");
                    roomDetection.GetComponent<RoomType>().DestroyRoom();
                    Instantiate(endRoom, transform.position, Quaternion.identity);
                }
              

                //Stop Generation
                stopGen = true;


            }
        }

    }
}
