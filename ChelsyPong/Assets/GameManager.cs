using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static int playerScore01 = 0;
    static int playerScore02 = 0;

    public GUISkin skin;
	
	public static void Score (string wallName) {
		if (wallName == "wallRight")
        {
            playerScore01++;
            Debug.Log("Player 1 Scored... Score is " + playerScore01.ToString() + "-" + playerScore02.ToString());
        }
        else
        {
            playerScore02++;
            Debug.Log("Player 2 Scored... Score is " + playerScore01.ToString() + "-" + playerScore02.ToString());
        }
	}

    public void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), playerScore01.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 20, 100, 100), playerScore02.ToString());

        if (GUI.Button ( new Rect (Screen.width / 2 - 121 / 2, 35, 121, 53), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;

            GameObject.Find("chelsyball").SendMessage("ResetBall");
        }
    }
}
