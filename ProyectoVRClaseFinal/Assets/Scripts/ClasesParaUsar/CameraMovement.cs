using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    int jumps = 1;
    [SerializeField] float speed = 3, jumpForce = 500;
    
    float rotationVertical;
    [SerializeField] float rotSpeed = 10f;

    
    public Camera cameraPlayer;

    public float sensitivity = 150f;
    public float clampAngle = 85f;
    private float verticalRotation;
    


    void Start()
    {


        verticalRotation = cameraPlayer.transform.localEulerAngles.x;
        
    }


    void Update()
    {

        Vector3 velocity = cameraPlayer.transform.forward * Input.GetAxis("Vertical") * speed;


#if UNITY_EDITOR
        if (!Application.platform.Equals("Android"))
        {
            float mouseVertical = -Input.GetAxis("Mouse Y") * rotSpeed;
            float mouseHorizontal = Input.GetAxis("Mouse X") * rotSpeed;
            rotationVertical += mouseVertical * sensitivity * Time.deltaTime;
            

            rotationVertical = Mathf.Clamp(rotationVertical, -clampAngle, clampAngle);

            cameraPlayer.transform.rotation = Quaternion.Euler(rotationVertical, transform.rotation.eulerAngles.y, 0);

        }
#endif

#if UNITY_ANDROID

        Vector3 velocityAndroid = cameraPlayer.transform.forward * Input.GetAxis("Vertical") * speed;
        
#endif

        if (Input.GetButtonDown("Fire1"))
        {


            Debug.Log("Presionando Fire1");

        }

        if (Input.GetButtonDown("Fire2"))
        {

        }
        if (Input.GetButtonDown("Fire3"))
        {

        }


    }
}
