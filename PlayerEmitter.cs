using UnityEngine;
using System.Collections;

public class PlayerEmitter : MonoBehaviour {

	public Bullet sampleBullet = null;
	public int Damage;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(sampleBullet == null)
			return;
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Bullet bullet = Instantiate(sampleBullet,this.transform.position,this.transform.rotation) as Bullet;
			bullet.Speed = 0.5f;
			bullet.SetDamage(Damage);
			bullet.SetForwardDirection(this.transform.forward);
			bullet.SetEnemy("ENEMY");
		}
	}
}
