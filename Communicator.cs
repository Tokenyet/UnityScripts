using UnityEngine;
using System.Collections;

public class Communicator : MonoBehaviour {

	public Communicate Communicate;
	public string Name;
	public string[] Contents;
	public Color TitleBackground;
	public Color ContentBackground;
	private bool openDialog = false;
	private bool inRange = false;
	private int dialogIndex = -1;

	// Use this for initialization
	void Start () {
		openDialog = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(openDialog && Input.GetKeyDown(KeyCode.Space))
		{
			Talking();
		}
		else if(Input.GetKeyDown(KeyCode.E) && inRange && !openDialog)
		{
			openDialog = true;
			Communicate.OpenDialog(openDialog);
			Talking();
		}

	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "PLAYER" && !inRange)
		{
			inRange = true;
			Communicate.OpenDialog(false);
			Communicate.SetName(Name);;
			Communicate.SetTitleBackground(TitleBackground);
			Communicate.SetContentBackground(ContentBackground);
		}
		else
		{
			inRange = false;
		}
	}

	bool Talking()
	{
		dialogIndex++;
		if (dialogIndex >= Contents.Length)
		{
			Reset();
			return false;
		}
		Communicate.SetContent (Contents[dialogIndex]);
		return true;
	}

	private void Reset()
	{
		inRange = false;
		openDialog = false;
		dialogIndex = -1;
		Communicate.OpenDialog(false);
	}
}
