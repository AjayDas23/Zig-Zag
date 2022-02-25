using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    public float lrprate;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            FollowB();
        }
    }

    void FollowB()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, lrprate * Time.deltaTime);
        transform.position = pos;
    }
}
