using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
           
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -10), Time.deltaTime * 5);
    }
}
