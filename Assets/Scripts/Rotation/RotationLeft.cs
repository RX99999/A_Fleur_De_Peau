using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This script handle the rotation to the left of a character while pressing a button
public class RotationLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject rotatedObject;
    public string name;
    public float rotationSpeed = 1000;
    bool rotate = false;

    
    public void FixedUpdate()
    {
        if (rotate == false)
            return;
 
        rotatedObject.transform.Rotate(0,-50f*Time.deltaTime,0);
    }
 
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        rotate = true;
    }
 
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        rotate = false;
    }
}
