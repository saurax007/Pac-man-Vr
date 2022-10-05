using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour {

    

    int jumps = 1;
    [SerializeField] float speed = 3, jumpForce = 500;
    float rotationHorizontal;
    float rotationVertical;
    [SerializeField] float rotSpeed = 10f;

    

    public Rigidbody rb;
    public Camera cameraPlayer;

    
    
   

    public float sensitivity = 150f;
    public float clampAngle = 85f;
    private float verticalRotation;
    private float horizontalRotation;


    void Start() {
        
        
        verticalRotation = cameraPlayer.transform.localEulerAngles.x;
        horizontalRotation = transform.eulerAngles.y;
    }

    
    void Update() {

        Vector3 velocity = cameraPlayer.transform.forward * Input.GetAxis("Vertical") * speed;
        transform.position += velocity * Time.deltaTime;

#if UNITY_EDITOR
        if (!Application.platform.Equals("Android"))
        {
            float mouseVertical = -Input.GetAxis("Mouse Y") * rotSpeed;
            float mouseHorizontal = Input.GetAxis("Mouse X") * rotSpeed;
            rotationVertical += mouseVertical * sensitivity * Time.deltaTime;
            rotationHorizontal += mouseHorizontal * sensitivity * Time.deltaTime;

            rotationVertical = Mathf.Clamp(rotationVertical, -clampAngle, clampAngle);
            cameraPlayer.transform.rotation = Quaternion.Euler(rotationVertical, 0f, 0f);
            
            RotatePlayerHorizontal();
        }
#endif

#if UNITY_ANDROID

        Vector3 velocityAndroid = cameraPlayer.transform.forward * Input.GetAxis("Vertical") * speed;
        transform.position += velocityAndroid * Time.deltaTime;
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
       

        if (Input.GetButtonDown("Jump")) {
            Jump();
            
        }

    }

    public void RotatePlayerHorizontal()
    {
        transform.Rotate(new Vector3(0f,rotationHorizontal,0f));

    }

 

    public void Jump() {
        if(jumps >= 1) {
            rb.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("suelo"))
        {
            jumps = 1;
        }
        
    }
}
