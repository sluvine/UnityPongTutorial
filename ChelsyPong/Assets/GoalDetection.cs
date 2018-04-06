using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "chelsyball")
        {
            GameManager.Score(transform.name);
            hitInfo.gameObject.SendMessage("ResetBall");
        }
	}
}
