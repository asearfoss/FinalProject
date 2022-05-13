using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameObject kingObj;

    // Start is called before the first frame update
    void Start()
    {
        kingObj = GameObject.Find("king");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(kingObj.transform.position.x, kingObj.transform.position.y - 1.0f, -10.0f);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.name == "enemy")
        {
            MoveKing.enemyLives = MoveKing.enemyLives - 1;
        }
    }
}
