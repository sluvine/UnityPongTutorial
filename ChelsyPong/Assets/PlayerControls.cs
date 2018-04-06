using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

		if (Input.GetKey(moveUp))
        {
            rigid.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            rigid.velocity = new Vector2(0, speed * -1);
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }
	}
}
