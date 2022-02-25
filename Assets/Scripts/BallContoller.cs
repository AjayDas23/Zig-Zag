using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContoller : MonoBehaviour
{
    [SerializeField]
    private float speed;
    bool initiate;
    Rigidbody rigbody;
    bool GameOver;
    public GameObject effect;

    void Awake()
    {
        rigbody = GetComponent<Rigidbody>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        initiate = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initiate)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigbody.velocity = new Vector3(speed, 0, 0);
                initiate = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast (transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            rigbody.velocity = new Vector3 (0, -25f, 0);
            Camera.main.GetComponent<FollowBall>().GameOver = true;
        }
        
        if (Input.GetMouseButtonDown(0) && !GameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rigbody.velocity.z > 0)
        {
            rigbody.velocity = new Vector3(speed, 0, 0);
        }

        else if (rigbody.velocity.x > 0)
        {
            rigbody.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Coins")
        {
            GameObject eff = Instantiate(effect, coll.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
            Destroy(eff, 1f);
            
        }
    }
}
