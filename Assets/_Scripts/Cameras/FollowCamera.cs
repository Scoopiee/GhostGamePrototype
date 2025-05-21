using UnityEngine;

public class FollowCamera: MonoBehaviour {
    
	public Transform target; // target to follow
	public float heightOffset = 5.0f; // height of the camera above the target
	
	void LateUpdate () {

		if (!target) return;

		transform.position = new Vector3(target.position.x,target.position.y,-heightOffset); // set camera position to target position with height offset
	}
}