using UnityEngine;
using System.Collections;

//Camera Follow With Player and Relocate direction(Forward&Right)
public class CameraFollow : MonoBehaviour {

	public PlayerController target;//the target object
	//private float horizontalSpeed = 40.0f;
	//private float verticalSpeed = 40.0f;
	private Vector3 targetOldPosition; //record old position to follow player
	private float speedMod = 1.0f;//a speed modifier
	//private Vector3 point;//the coord to the point where the camera looks at


	void Start () {//Set up things on the start method
		//point = target.transform.position;//get target's coords
		transform.LookAt(target.transform.position);//makes the camera look to it 
		target.SetForwardDirection(Camera.main.transform.up);
		target.SetRightDirection (Camera.main.transform.right);
	}
	
	
	
	void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
		float delta_x =  target.transform.position.x - targetOldPosition.x;
		float delta_y = target.transform.position.y - targetOldPosition.y;
		float delta_z = target.transform.position.z - targetOldPosition.z;
		float locate_x = this.transform.position.x + delta_x;
		float locate_y = this.transform.position.y + delta_y;
		float locate_z = this.transform.position.z + delta_z;
		this.transform.position = new Vector3 (locate_x, locate_y, locate_z);
		if(Input.GetMouseButton (1))
		{
			//float h = horizontalSpeed * Input.GetAxis ("Mouse Y");
			float rotateYAxis = Input.GetAxis ("Mouse X");
			transform.RotateAround (target.transform.position,new Vector3(0.0f,1.0f,0.0f),1 * rotateYAxis * speedMod);
			//transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * speedMod);
		}
		target.SetForwardDirection(Camera.main.transform.up);
		target.SetRightDirection (Camera.main.transform.right);
		targetOldPosition = target.transform.position;
	}
}
