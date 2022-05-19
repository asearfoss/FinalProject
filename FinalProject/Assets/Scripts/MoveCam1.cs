using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam1 : MonoBehaviour
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
        transform.position = new Vector3(kingObj.transform.position.x, kingObj.transform.position.y + 1.25f, -10.0f);
    }
}
