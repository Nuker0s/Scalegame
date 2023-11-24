using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleanim : MonoBehaviour
{
    private Transform targetTransform;
    public Transform toanimate;
    public Transform target;
    public float duration = 2f;
    public AnimationCurve animationCurve;
    public bool button;
    public Vector3 initialPosition;
    public Quaternion initialRotation;
    public float currentTime = 0f;
    public bool isAnimating = false;

    void Start()
    {
        // Store the initial position and rotation of the object
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        targetTransform = target;
    }

    void Update()
    {
        if (button)
        {
            button = false;
            StartAnimation();
        }
        if (isAnimating)
        {
            // Increment the time based on the animation curve
            currentTime = Mathf.Clamp01(currentTime + Time.deltaTime / duration * animationCurve.Evaluate(currentTime));


            toanimate.position = Vector3.Lerp(initialPosition, targetTransform.position, currentTime);
            toanimate.rotation = Quaternion.Slerp(initialRotation, targetTransform.rotation, currentTime);

            // If we reached the target, reverse the animation
            if (currentTime >= 1f)
            {
                isAnimating = false;
                SwapTargets();
                if (targetTransform==target)
                {
                    
                }
                else
                {
                    StartAnimation();
                }
                
            }
        }
    }

    // Trigger the animation to start from the initial position
    public void StartAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            currentTime = 0f;
        }
    }

    // Swap initial and target values for the next animation
    void SwapTargets()
    {
        if (targetTransform==transform)
        {
            targetTransform = target;
            initialPosition = transform.position;

            
            
            initialRotation = transform.rotation;
            
        }
        else
        {
            
            initialPosition = targetTransform.position;

            targetTransform = transform;
           
            initialRotation = targetTransform.rotation;
            
        }

    }
}




