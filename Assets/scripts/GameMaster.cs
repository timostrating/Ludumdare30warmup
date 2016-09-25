using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	private int currentLevel;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			currentLevel = Application.loadedLevel;
			Application.LoadLevel(currentLevel + 1);
		}
	}
}
