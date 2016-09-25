using UnityEngine;
using System.Collections;

public class verschijnScript : MonoBehaviour {
	private bool trigger = false;
	public GameObject verschijn;

	// Use this for initialization
	void Start () {
		verschijn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(trigger){ 
			verschijn.SetActive(true);
			Debug.Log ("verschijnd");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player")
		{
			Debug.Log ("verschijn dingen");
			trigger = true;
		}
	}
}
