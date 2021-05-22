using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public AudioSource ausrc;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;


    public Transform[] safePoints;
    public Transform closestTransform;
   
   private void Awake(){

     

       
   }
  


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        PlaySound();

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetCar();

        }
    }


    void ResetCar()
 {
     // first, find the closest safe place
     
     float closestDistance = 9999999999;
     Vector3 currentPos = transform.position;
     // This goes through every possible safe place and picks the best one
     foreach(Transform trans in safePoints)
     {
         float currentDistance = Vector3.Distance(currentPos, trans.position);
         if(currentDistance < closestDistance)
         {
             closestDistance = currentDistance;
             closestTransform = trans;
         }
     }
 
     // Now we reset the car!
     transform.position = closestTransform.position;
     transform.rotation = closestTransform.rotation;
 }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot
;       wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void PlaySound(){


        if (Input.GetAxis("Vertical") != 0)
        {
            var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
            var speed = vel.magnitude;
            
            if(speed < 3f)
            speed = 5f;
            
			ausrc.pitch = Mathf.Lerp(ausrc.pitch, speed / 5, 0.005f);	
			ausrc.volume = Mathf.Lerp(ausrc.volume, 1, 0.1f);

        }
		
		else{
			ausrc.pitch = Mathf.Lerp(ausrc.pitch, 1f, 0.01f);
			ausrc.volume = Mathf.Lerp(ausrc.volume, 0.7f, 0.1f);
        }
    }
}
