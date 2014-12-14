using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Slider Slider;
	public int Hp;
	private int hp;
	// Use this for initialization
	void Start () {
		hp = Hp;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool Damage(int damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			hp = 0;
			UpdateSlider ();
			return true;
		}
		UpdateSlider ();
		return false;
	}

	public void Heal(int heal)
	{
		if(hp <= Hp)
			hp += heal;
		UpdateSlider ();
	}

	private void UpdateSlider()
	{
		float f_hp = (float)hp;
		float f_Hp = (float)Hp;
		Slider.value = Slider.maxValue *f_hp/f_Hp;
	}
}
