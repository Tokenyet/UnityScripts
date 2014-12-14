using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthEnemy : Health {

	public float Offset_Height = 15.0f;
	public Canvas canvas;
	private bool initizlize = true;

	// Use this for initialization
	void Start () {
		hp = Hp;
	}
	
	// Update is called once per frame
	void Update () {
		initializeSlider (ref initizlize);
		Vector3 position = Camera.main.WorldToScreenPoint (this.transform.position);	
		float pX = position.x;
		float pY = position.y;
		float pZ = position.z;
		Vector3 fixPosition = new Vector3 (pX, pY+Offset_Height, pZ);
		Slider.transform.position = fixPosition;
	}
	

	private void initializeSlider(ref bool init)
	{
		if(init)
		{
			Slider slider = Instantiate (Slider) as Slider;
			Slider = slider;
			Slider.value = Slider.maxValue;
			Slider.transform.parent = canvas.transform;
			init = false;
		}
	}
}
