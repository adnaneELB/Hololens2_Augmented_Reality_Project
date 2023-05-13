using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Microsoft.MixedReality.Toolkit.Input;

public class LongClick : MonoBehaviour, IMixedRealityPointerHandler
{ 
    public float longPressDuration = 1f;
    public float pressDistanceThreshold = 0.01f;

    private bool isPressed;
    private bool isLongPressed;
    private float pressTime;

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        isPressed = true;
        pressTime = Time.time;
        StartCoroutine(LogWhilePressed());
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        if (isPressed && !isLongPressed)
        {
            if (Time.time - pressTime < longPressDuration && Vector3.Distance(eventData.Pointer.Position, transform.position) < pressDistanceThreshold)
            {
                // Short press
                Debug.Log("Button short pressed!");
            }
            else
            {
                isLongPressed = true;
                Debug.Log("Button long pressed!");
            }
        }

        isPressed = false;
        StopCoroutine(LogWhilePressed());
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }

   

    public IEnumerator LogWhilePressed()
    {
        while (isPressed)
        {
            Debug.Log("Button is pressed!");
            yield return null;
        }
    }
}
