using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class MainCamera : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float sensitivityScroll = 15f;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float positionX = 0F;
    float positionZ = 0F;

    float minFov = 15f;
    float maxFov = 90f;

    Vector3 orinalPosition;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                positionZ += Input.GetAxis("Mouse Y") * sensitivityY;
                positionX += Input.GetAxis("Mouse X") * sensitivityX;
                transform.localPosition = orinalPosition + new Vector3(-positionX, 0f, -positionZ);
            }
            else if (axes == RotationAxes.MouseX)
            {
                positionX += Input.GetAxis("Mouse X") * sensitivityX;
                transform.localPosition = orinalPosition + new Vector3(-positionX, 0f, -positionZ);
            }
            else
            {
                positionZ += Input.GetAxis("Mouse Y") * sensitivityY;
                transform.localPosition = orinalPosition + new Vector3(0f, 0f, -positionZ);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel")>1|| Input.GetAxis("Mouse ScrollWheel") < 1)
        {
            Debug.Log("Scroll in");
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView+Input.GetAxis("Mouse ScrollWheel") * sensitivityScroll, minFov, maxFov);
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        orinalPosition = transform.localPosition;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }
}