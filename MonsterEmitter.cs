using UnityEngine;
using System.Collections;

public class MonsterEmitter : MonoBehaviour {
	public Bullet sampleBullet = null;
	private float shootingCounting;
	// Use this for initialization
	void Start () {
		shootingCounting = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(sampleBullet == null)
			return;
		shootingCounting += Time.deltaTime;
		Debug.Log (shootingCounting);
		if(shootingCounting > 1.5f)
		{
			shootingCounting = 0;
			Bullet bullet = Instantiate(sampleBullet,this.transform.position,this.transform.rotation) as Bullet;
			bullet.Speed = 0.5f;
			bullet.SetForwardDirection(this.transform.forward);
			bullet.SetEnemy("PLAYER");
		}
	}
}
