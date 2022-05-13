using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKing1 : MonoBehaviour
{
    float lastXPos;
    float lastYPos;
    public static Vector3 flip;
    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        flip = new Vector3(5.0f, 5.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        flipKing();
        transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime, 0.0f, 0.0f);
        transform.Translate(0.0f, Input.GetAxis("Vertical") * 10.0f * Time.deltaTime, 0.0f);

        if (transform.position.x != lastXPos)
        {
            animate.SetFloat("TransAnim", 1);
        }
        else if (transform.position.y != lastYPos)
        {
            animate.SetFloat("TransAnim", 2);
        }
        else
        {
            animate.SetFloat("TransAnim", 0);
        }

        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    void flipKing()
    {
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            flip.x = -5.0f;
        }

        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            flip.x = 5.0f;
        }

        transform.localScale = flip;
    }
}
