using UnityEngine;
using System.Collections;

public class DoodTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if(other.transform.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel);
			Debug.Log ("DOOD");
		}
	}
}
