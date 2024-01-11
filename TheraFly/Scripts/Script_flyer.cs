//Ka Man CHOI 50000567 - TheraFly
//control waving position - velocity collected from controller
//references from youtube tutorials
// https://youtu.be/ViQzKZvYdgE; https://youtu.be/9PxHzcWCAtY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class Script_Flyer : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float flyForce = 2f;
    [SerializeField] float dragForce = 1f;
    [SerializeField] float minForce;
    [SerializeField] float minTimeBetweenStrokes;

    [Header("References")]
    [SerializeField] InputActionReference leftControllerFlyReference;
    [SerializeField] InputActionReference leftControllerVelocity;
    [SerializeField] InputActionReference righttControllerFlyReference;
    [SerializeField] InputActionReference rightControllerVelocity;
    [SerializeField] Transform trackReference; //will be use head to orient the forward direction

    Rigidbody _human; //get the physics for flying
    float _cooldownTimer; //calculate for time between strokes

    void Awake()
    {
        _human = GetComponent<Rigidbody>();
        _human.useGravity = false; //sense of flowing
        _human.constraints = RigidbodyConstraints.FreezeRotation; //prevent motion sickness
    }

    private void FixedUpdate()
    {
        _cooldownTimer += Time.fixedDeltaTime; 

        //check if both hand control is pressed
        if(_cooldownTimer > minTimeBetweenStrokes 
            && leftControllerFlyReference.action.IsPressed() 
            && righttControllerFlyReference.action.IsPressed())
        {
            var leftHandVelocity = leftControllerVelocity.action.ReadValue<Vector3>();
            var rightHandVelocity = rightControllerVelocity.action.ReadValue<Vector3>();
            Vector3 localVelocity = leftHandVelocity + rightHandVelocity;
            localVelocity *= -1; // when both hands are grab backward, go forward

            if (localVelocity.sqrMagnitude > minForce * minForce) {
                Vector3 worldVelocity = trackReference.TransformDirection(localVelocity); //how quick
                _human.AddForce(worldVelocity * flyForce, ForceMode.Acceleration);
                _cooldownTimer = 0f;
            }

            Debug.Log(minTimeBetweenStrokes);
        }
        //dragforce when user is moving
        if (_human.velocity.sqrMagnitude > 0.01f)
        {
            _human.AddForce(_human.velocity * dragForce, ForceMode.Acceleration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
