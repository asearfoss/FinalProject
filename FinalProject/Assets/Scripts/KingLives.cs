using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingLives : MonoBehaviour
{
    public Text lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveEnemy.kingLives < 0.5)
        {
            lives.text = "GAME OVER!";
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        {
            lives.text = "Lives: " + MoveEnemy.kingLives + "/5.0";
        }
    }
}
