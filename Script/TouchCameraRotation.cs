using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraRotation : BasicCameraRotation
{
    Vector3 firstPoint;
    public float sensitivity = 2.5f;
    private static readonly float ZoomSpeedTouch = 0.1f;
    
    private static readonly float[] ZoomBounds = new float[]{10f, 85f};
    
    private Camera cam;
    
    private Vector3 lastPanPosition;
    
    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only

    void Awake() 
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
       TouchRotation();
       HandleTouch();
    }
    void TouchRotation()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstPoint = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 secondPoint = Input.GetTouch(0).position;

                float x = FilterGyroValues(secondPoint.x - firstPoint.x);
                RotateRightLeft(x * sensitivity);

                float y = FilterGyroValues(secondPoint.y - firstPoint.y);
                RotateUpDown(y * -sensitivity);

                firstPoint = secondPoint;
            }
        }
    }
    float FilterGyroValues(float axis)
    {
        float thresshold = 0.5f;
        if (axis < -thresshold || axis > thresshold)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }

      void HandleTouch() {
        switch(Input.touchCount) {
    
        case 2: // Zooming
            Vector2[] newPositions = new Vector2[]{Input.GetTouch(0).position, Input.GetTouch(1).position};
            if (!wasZoomingLastFrame) {
                lastZoomPositions = newPositions;
                wasZoomingLastFrame = true;
            } else {
                // Zoom based on the distance between the new positions compared to the 
                // distance between the previous positions.
                float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                float offset = newDistance - oldDistance;
    
                ZoomCamera(offset, ZoomSpeedTouch);
    
                lastZoomPositions = newPositions;
            }
            break;
            
        default: 
            wasZoomingLastFrame = false;
            break;
        }
    }

    void ZoomCamera(float offset, float speed) {
        if (offset == 0) {
            return;
        }
    
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
    }
}
