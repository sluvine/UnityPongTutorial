using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

    public Camera mainCam;

    public BoxCollider2D wallTop;
    public BoxCollider2D wallBottom;
    public BoxCollider2D wallLeft;
    public BoxCollider2D wallRight;

    public Transform Player01;
    public Transform Player02;

	// Update is called once per frame
	void Start () {
        wallTop.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        wallTop.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3 (0f, Screen.height, 0f)).y + 0.5f);

        wallBottom.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        wallBottom.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        wallLeft.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        wallLeft.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        wallRight.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        wallRight.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        Player01.position = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(5f, 0f, 0f)).x, 0f);
        Player02.position = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 5f, 0f, 0f)).x, 0f);
    }
}
