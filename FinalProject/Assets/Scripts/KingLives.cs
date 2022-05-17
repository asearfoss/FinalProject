using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingLives : MonoBehaviour
{
    public static Text lives;

    // Update is called once per frame
    void Update()
    {
        if (MoveEnemy.kingLives < 0.5 || MoveKing.enemiesLeft < 1)
        {
            if (MoveKing.enemiesLeft < 1)
            {
                KingLives.lives.text = "WINNER!";
            }
            if (MoveEnemy.kingLives < 0.5)
            {
                lives.text = "GAME OVER!";
            }

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
