using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Communicate : MonoBehaviour {

	public Text Name;
	public Text Content;
	public Image TitleBackground;
	public Image ContentBackground;

	// Use this for initialization
	void Start () {
		OpenDialog (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OpenDialog(bool open)
	{
		bool active = open;
		Name.gameObject.SetActive(active);
		Content.gameObject.SetActive(active);
		TitleBackground.gameObject.SetActive(active);
		ContentBackground.gameObject.SetActive(active);
	}

	public void SetContent(string content)
	{
		Content.text = content;
	}

	public void SetName(string name)
	{
		Name.text = name;
	}	

	public void SetTitleBackground(Color color)
	{
		TitleBackground.color = color;
	}
	public void SetContentBackground(Color color)
	{
		ContentBackground.color = color;
	}
}
