using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Vector3 forwardDirection;
	private bool lockDirection = false;
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
		if (other.tag == "ENEMY")
			Destroy(this.gameObject);
	}

	public void SetForwardDirection(Vector3 forward)
	{
		if(!lockDirection)
		{
			forwardDirection = forward;
			lockDirection = true;
		}
	}
}
