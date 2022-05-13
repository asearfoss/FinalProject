using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKing : MonoBehaviour
{
    public Animator animate;
    Collision collision;
    Vector3 lastPos;
    float lastXPos;
    float lastYPos;
    public static Vector3 flip;
    public GameObject enemyObj1;
    Vector3 enemyPos;
    public GameObject enemyObj;
    Vector3 enemyPos1;
    float dist;
    float dist1;
    public static int enemyLives;

    // Start is called before the first frame update
    void Start()
    {
        flip = new Vector3(10.0f, 10.0f, 0.0f);
        enemyObj = GameObject.Find("Enemy");
        enemyObj1 = GameObject.FindWithTag("Enemy1");

        lastPos = transform.position;
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        flipKing();
        enemyPos = new Vector3(enemyObj.transform.position.x, enemyObj.transform.position.y, 0.0f);
        enemyPos1 = new Vector3(enemyObj1.transform.position.x, enemyObj1.transform.position.y, 0.0f);
        dist = Vector3.Distance(enemyPos, transform.position);
        dist1 = Vector3.Distance(enemyPos1, transform.position);
        transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime, 0.0f, 0.0f);
        transform.Translate(0.0f, Input.GetAxis("Vertical") * 10.0f * Time.deltaTime, 0.0f);

        if (transform.position.x != lastXPos)
        {
            animate.SetFloat("TransAnim", 1);
        }
        if (transform.position.y != lastYPos)
        {
            ifYChange();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animate.SetFloat("TransAnim", 4);
        }
        if (transform.position == lastPos && !Input.GetKeyDown(KeyCode.Space))
        {
            animate.SetFloat("TransAnim", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && dist < 5.0f)
        {
            enemyLives = enemyLives - 1;
            animate.SetFloat("TransAnim", 4);
        }
        if (Input.GetKeyDown(KeyCode.Space) && dist1 < 5.0f)
        {
            enemyLives = enemyLives - 1;
            animate.SetFloat("TransAnim", 4);
        }

        lastPos = transform.position;
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    void flipKing()
    {
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            flip.x = -10.0f;
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            flip.x = 10.0f;
        }

        transform.localScale = flip;
    }

    void ifYChange()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            animate.SetFloat("TransAnim", 2);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            animate.SetFloat("TransAnim", 3);
        }
    }
}
