using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Vector3 forwardDirection;
	private bool lockDirection = false;
	private List<string> enemy_tags;
	private int damage = 2;
	public float Speed = 0.5f;


	// Use this for initialization
	void Start () {
		/*forwardDirection = new Vector3 (1, 0, 0);
		lockDirection = false;*/
		//Destroy (this, 1);//buggy
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		float pX = this.transform.position.x;
		float pZ = this.transform.position.z;
		float pY = this.transform.position.y;
		pX += forwardDirection.x * Speed;
		pY += forwardDirection.y * Speed;
		pZ += forwardDirection.z * Speed;
		this.transform.position = new Vector3 (pX, pY, pZ);
	}

	void OnTriggerEnter(Collider other) {
		foreach(string enemy in enemy_tags)
		{
			if(other.tag == enemy)
			{
				Health hp = other.GetComponent<Health>();
				hp.Damage(damage);
				Destroy(this.gameObject);
				break;
			}
		}
	}

	public void SetForwardDirection(Vector3 forward)
	{
		if(!lockDirection)
		{
			forwardDirection = forward;
			lockDirection = true;
		}
	}

	public void SetEnemy(string enemy)
	{
		if(enemy_tags == null)
			enemy_tags = new List<string> ();
		enemy_tags.Add (enemy);
	}

	public void SetEnemys(IEnumerable<string> enemies)
	{
		IEnumerator<string> iterator = enemies.GetEnumerator();
		while (iterator.MoveNext())
			SetEnemy (iterator.Current);
	}

	public void SetDamage(int damage)
	{
		if (damage < 0)
			return;
		this.damage = damage;
	}
}
