using UnityEngine;
using System.Collections;

public class vuurvliegje : MonoBehaviour {
	public enum textBox{Text1 = 0, Text2, Text3, Text4, Agresief}
	public textBox text = textBox.Text1;
	private int Level;
	private int textVersie = 0;
	private int wKopie;

	// GUI butten afstanden
	private int x;
	private int y;
	private int w;
	private int h;
	private int tussenRuimte;

	// bools om bij te houden welke knop ingedrukt werdt
	private bool pressed1 = false;
	private bool pressed2 = false;
	private bool pressed3 = false;
	private bool reageerdAgresief = false;

	// text vvor de knoppen
	private string TextEen;
	private string TextTwee;
	private string TextDrie;

	// this is called before everything
	void Awake () {
		Level = Application.loadedLevel;
		Debug.Log ("Level " + Level);
	}

	void Start () {
		if(Level == 0) {
		#region set alle text uit level 1 uit
		GameObject A = GameObject.Find("Text1");
		MeshRenderer Text1 = A.GetComponent<MeshRenderer>();
		Text1.GetComponent<Renderer>().enabled = false;
		GameObject B = GameObject.Find("Text2");
		MeshRenderer Text2 = B.GetComponent<MeshRenderer>();
		Text2.GetComponent<Renderer>().enabled = false;
		GameObject Ceen = GameObject.Find("Text3een");
		MeshRenderer Text3een = Ceen.GetComponent<MeshRenderer>();
		Text3een.GetComponent<Renderer>().enabled = false;
		GameObject Ctwee = GameObject.Find("Text3twee");
		MeshRenderer Text3twee = Ctwee.GetComponent<MeshRenderer>();
		Text3twee.GetComponent<Renderer>().enabled = false;
		GameObject D = GameObject.Find("Text4");
		MeshRenderer Text4 = D.GetComponent<MeshRenderer>();
		Text4.GetComponent<Renderer>().enabled = false;
		#endregion 
		}

		w = 250;
		wKopie = w / 2;
		x = Screen.width / 2 - wKopie;
		y = 25;
		h = 50;
		tussenRuimte = 400;

	}

	void OnGUI() {
		if(Level == 0) {
			if(textVersie == 1 || textVersie > 1 ){
				Menukeuze();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Level == 0) {
			if(Input.GetKeyDown(KeyCode.Space) || pressed1 || pressed2 || pressed3) {
				textVersie += 1;
				if(pressed1 || pressed2 || pressed3){
					pressed1 = false;
					pressed2 = false;
					pressed3 = false;
					if(textVersie == 1) {   
						TextEen = "Hallo"; 
						TextTwee = "Good evening"; 
						TextDrie = "bye";
						text = textBox.Text1; }
					else if(textVersie == 2) {  
						TextEen = "I am walking here"; 
						TextTwee = "nothing"; 
						TextDrie = "sothing you dont need to now";
						text = textBox.Text2;}
					else if(textVersie == 3) { 
						TextEen = "I wil be carefull"; 
						TextTwee = "I now"; 
						TextDrie = "i am not little";
						text = textBox.Text3; }
					else if(textVersie == 4) {  
						TextEen = "thanks for the advise"; 
						TextTwee = "I will remember that"; 
						TextDrie = "i do not care";
						text = textBox.Text4;}
					else if(reageerdAgresief){
						text = textBox.Agresief;
						Debug.Log("reageerdAgresief");
					}
				}

				else if(textVersie == 1){ 
					// Hallo litte girl
					TextEen = "Hallo";
					TextTwee = "Good evening";
					TextDrie = "bye";
					text = textBox.Text1;
					Debug.Log("Text1");
				}
				else if(textVersie == 2){
					// Wat are you doing here?
					TextEen = "I am walking here";
					TextTwee = "nothing";
					TextDrie = "sothing you dont need to now";
					text = textBox.Text2;
					Debug.Log("Text2");
				}
				else if(textVersie == 3){
					//this is a very dangeres place for a little girl like you.
					TextEen = "I wil be carefull";
					TextTwee = "I now";
					TextDrie = "i am not little";
					text = textBox.Text3;
					Debug.Log("Text3");
				}
				else if(textVersie == 4){
					// but nothing is what it looks like.
					TextEen = "thanks for the advise";
					TextTwee = "I will remember that";
					TextDrie = "i do not care";
					text = textBox.Text4;
					Debug.Log("Text4");
				}
				else if(reageerdAgresief = true){
					text = textBox.Agresief;
					Debug.Log("reageerdAgresief");
				}

				switch(text)
				{
				case(textBox.Text1):
					GameObject press = GameObject.Find("press space");
					MeshRenderer pressSpace = press.GetComponent<MeshRenderer>();
					pressSpace.GetComponent<Renderer>().enabled = false;
					
					GameObject A = GameObject.Find("Text1");
					MeshRenderer Text1 = A.GetComponent<MeshRenderer>();
					Text1.GetComponent<Renderer>().enabled = true;
					break;
					
				case(textBox.Text2):
					GameObject AKopie = GameObject.Find("Text1");
					MeshRenderer Text1Kopie = AKopie.GetComponent<MeshRenderer>();
					Text1Kopie.GetComponent<Renderer>().enabled = false;
					
					GameObject B = GameObject.Find("Text2");
					MeshRenderer Text2 = B.GetComponent<MeshRenderer>();
					Text2.GetComponent<Renderer>().enabled = true;
					break;
					
				case(textBox.Text3):
					GameObject BKopie = GameObject.Find("Text2");
					MeshRenderer Text2Kopie = BKopie.GetComponent<MeshRenderer>();
					Text2Kopie.GetComponent<Renderer>().enabled = false;
					
					GameObject Ceen = GameObject.Find("Text3een");
					MeshRenderer Text3een = Ceen.GetComponent<MeshRenderer>();
					Text3een.GetComponent<Renderer>().enabled = true;
					GameObject Ctwee = GameObject.Find("Text3twee");
					MeshRenderer Text3twee = Ctwee.GetComponent<MeshRenderer>();
					Text3twee.GetComponent<Renderer>().enabled = true;
					break;
					
				case(textBox.Text4):
					GameObject CeenKopie = GameObject.Find("Text3een");
					MeshRenderer Text3eenKopie = CeenKopie.GetComponent<MeshRenderer>();
					Text3eenKopie.GetComponent<Renderer>().enabled = false;
					GameObject CtweeKopie = GameObject.Find("Text3twee");
					MeshRenderer Text3tweeKopie = CtweeKopie.GetComponent<MeshRenderer>();
					Text3tweeKopie.GetComponent<Renderer>().enabled = false;
					
					GameObject D = GameObject.Find("Text4");
					MeshRenderer Text4 = D.GetComponent<MeshRenderer>();
					Text4.GetComponent<Renderer>().enabled = true;
					break;

				case(textBox.Agresief):
					GameObject DKopie = GameObject.Find("Text4");
					MeshRenderer Text4Kopie = DKopie.GetComponent<MeshRenderer>();
					Text4Kopie.GetComponent<Renderer>().enabled = false;

					GameObject AG = GameObject.Find("TextAG");
					MeshRenderer TextAG = AG.GetComponent<MeshRenderer>();
					TextAG.GetComponent<Renderer>().enabled = true;
					break;
				}
			}
		}
	}

	void Menukeuze() {

		if(GUI.Button(new Rect(	x - tussenRuimte,
		                    	y,
		                   		w,
		                       	h), TextEen)) {
			pressed1 = true;
			Debug.Log(pressed1);
		}

		if(GUI.Button(new Rect(	x,
		                    	y,
		                    	w,
		                       	h), TextTwee)) {
			pressed2 = true;
			Debug.Log(pressed2);
		}

		if(GUI.Button(new Rect(	x + tussenRuimte,
		                    	y,
		                    	w,
		                       	h), TextDrie)) {
			pressed3 = true;
			reageerdAgresief = true;
			Debug.Log(pressed3);
		}
	}
}
