using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Vector3 forwardDirection,rightDirection;
	public float ForwardSpeed = 0.1f;
	public float BackwardSpeed = 0.1f;
	public float SideSpeed = 0.1f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float pX = this.transform.position.x;
		float pZ = this.transform.position.z;
		float pY = this.transform.position.y;

		if (Input.GetKey (KeyCode.W))
		{
			pX += forwardDirection.x * ForwardSpeed;
			pY += forwardDirection.y * ForwardSpeed;
			pZ += forwardDirection.z * ForwardSpeed;
			this.transform.forward = forwardDirection;//按了轉身
		}
		if (Input.GetKey (KeyCode.S))
		{
			pX -= forwardDirection.x * BackwardSpeed;
			pY -= forwardDirection.y * BackwardSpeed;
			pZ -= forwardDirection.z * BackwardSpeed;
		}
		if (Input.GetKey (KeyCode.A))
		{
			pX -= rightDirection.x * SideSpeed;
			pY -= rightDirection.y * SideSpeed;
			pZ -= rightDirection.z * SideSpeed;
		}
		if (Input.GetKey (KeyCode.D))
		{
			pX += rightDirection.x * SideSpeed;
			pY += rightDirection.y * SideSpeed;
			pZ += rightDirection.z * SideSpeed;
		}
		this.transform.position = new Vector3 (pX, pY, pZ);

	}

	public void SetForwardDirection(Vector3 forward)
	{
		forwardDirection = forward;
		forwardDirection.y = 0;
		//this.transform.forward = forwardDirection;//隨時轉身
	}

	public void SetRightDirection(Vector3 right)
	{
		rightDirection = right;
		rightDirection.y = 0;
	}

}
