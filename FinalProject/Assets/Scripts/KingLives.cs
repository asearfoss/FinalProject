using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingLives : MonoBehaviour
{
    public Text lives;

    // Update is called once per frame
    void Update()
    {
        if (MoveKing.enemiesLeft < 1)
        {
            lives.text = "WINNER!";
            Invoke("endGame", 4.0f);
        }
        else if (MoveEnemy.kingLives < 0.5f)
        {
            lives.text = "GAME OVER!";
            Invoke("endGame", 2.0f);
        }
        else
        {
            lives.text = "Lives: " + MoveEnemy.kingLives + "/5.0";
        }
    }

    void endGame()
    {
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
