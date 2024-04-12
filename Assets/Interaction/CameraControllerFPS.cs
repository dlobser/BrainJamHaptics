using UnityEngine;
using System.Collections;


	/// <summary>
	/// The very simple FPS camera.
	/// </summary>
	public class CameraControllerFPS: MonoBehaviour {

	public float rotationSensitivity = 3f;
	public float yMinLimit = -89f;
	public float yMaxLimit = 89f;
    public float speed = 1;
	private float x, y, tx,ty,tz;

	void Awake () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
        tx = 0;
        ty = 0;
        tz = 0;
	}

	public void LateUpdate() {
		Cursor.lockState = CursorLockMode.Locked;

		x += Input.GetAxis("Mouse X") * rotationSensitivity;
		y = ClampAngle(y - Input.GetAxis("Mouse Y") * rotationSensitivity, yMinLimit, yMaxLimit);
        tx = Input.GetKey(KeyCode.A) ? speed : 0;
        if(tx==0)
            tx = Input.GetKey(KeyCode.D) ? -speed : 0;
        tz = Input.GetKey(KeyCode.W) ? speed : 0;
        if(tz==0)
            tz = Input.GetKey(KeyCode.S) ? -speed : 0;
        ty = Input.GetKey(KeyCode.E) ? speed : 0;
        if(ty==0)
            ty = Input.GetKey(KeyCode.Q) ? -speed : 0;
        Debug.Log(tx);
		// Rotation
		transform.rotation = Quaternion.AngleAxis(x, Vector3.up) * Quaternion.AngleAxis(y, Vector3.right);
        transform.Translate(new Vector3(tx, ty, tz));
	}

	// Clamping Euler angles
	private float ClampAngle (float angle, float min, float max) {
		if (angle < -360) angle += 360;
		if (angle > 360) angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}

}

