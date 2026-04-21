using UnityEngine;

public class AllignedController : MonoBehaviour
{
    public Transform sceneRoot;

    public float moveSpeed = 0.5f;
    public float rotateSpeed = 60f;
    public float verticalSpeed = 0.3f;
    public float deadZone = 0.15f;

    void Update()
    {
        OVRInput.Update();

        if (sceneRoot == null) return;

        // assign to left/right hand
        Vector2 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector2 rightStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        if (leftStick.magnitude < deadZone) leftStick = Vector2.zero;
        if (rightStick.magnitude < deadZone) rightStick = Vector2.zero;

        // shift 
        Vector3 move = new Vector3(leftStick.x, 0f, -leftStick.y) * moveSpeed * Time.deltaTime;
        sceneRoot.position += move;

        // rotation
        float yaw = rightStick.x * rotateSpeed * Time.deltaTime;
        sceneRoot.Rotate(Vector3.up, yaw, Space.World);

        // up dowan
        float upDown = rightStick.y * verticalSpeed * Time.deltaTime;
        sceneRoot.position += Vector3.up * upDown;

        // scaling
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > deadZone)
            sceneRoot.localScale += new Vector3(1.0f, 1.0f, 1.0f);
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > deadZone)
            sceneRoot.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
        
        if (leftStick != Vector2.zero || rightStick != Vector2.zero)
        {
            Debug.Log($"Left:{leftStick} Right:{rightStick}");
        }
    }
}