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
    Vector2 enemyPos;
    public GameObject enemyObj;
    Vector2 enemyPos1;
    float dist;
    float dist1;
    public static int enemyLives = 2;
    public static int enemyLives1 = 2;
    public static int enemiesLeft = 2;

    // Start is called before the first frame update
    void Start()
    {
        flip = new Vector3(10.0f, 10.0f, 0.0f);
        enemyObj = GameObject.Find("enemy");
        enemyObj1 = GameObject.Find("enemy1");

        lastPos = transform.position;
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        flipKing();
        enemyPos = new Vector2(enemyObj.transform.position.x, enemyObj.transform.position.y);
        enemyPos1 = new Vector2(enemyObj1.transform.position.x, enemyObj1.transform.position.y);
        dist = Vector2.Distance(enemyPos, transform.position);
        dist1 = Vector2.Distance(enemyPos1, transform.position);
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
        if (Input.GetKeyDown(KeyCode.Space) && dist < 2.0f)
        {
            enemyLives = enemyLives - 1;
            animate.SetFloat("TransAnim", 4);
        }
        if (Input.GetKeyDown(KeyCode.Space) && dist1 < 2.0f)
        {
            enemyLives = enemyLives1 - 1;
            animate.SetFloat("TransAnim", 4);
        }

        if (enemyLives < 1)
        {
            Destroy(enemyObj);
            enemiesLeft = enemiesLeft - 1;
        }
        if (enemyLives1 < 1)
        {
            Destroy(enemyObj1);
            enemiesLeft = enemiesLeft - 1;
        }
        if (enemiesLeft < 1)
        {
            KingLives.lives.text = "WINNER!";
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
