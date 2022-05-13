using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Animator animate;
    Vector3 flip;
    public GameObject kingObj;
    Vector3 kingPos;
    public static float kingLives = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        kingObj = GameObject.Find("king");
        flip = new Vector3(-10.0f, 10.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        kingPos = new Vector3(kingObj.transform.position.x, kingObj.transform.position.y - 1.0f, 0.0f);
        flipEnemy();
        transform.position = Vector3.MoveTowards(transform.position, kingPos, 0.005f);

        if (MoveKing.enemyLives < 1)
        {
            Destroy(gameObject);
        }
    }

    void flipEnemy()
    {
        if (kingPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(10.0f, 10.0f, 0.0f);
        }
        else
        {
            transform.localScale = new Vector3(-10.0f, 10.0f, 0.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "king")
        {
            enemyAttack();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        animate.SetFloat("EnemyTransAnim", 0.0f);
    }

    public void enemyAttack()
    {
        animate.SetFloat("EnemyTransAnim", 1.0f);
        kingLives = kingLives - 0.5f;
    }
}
