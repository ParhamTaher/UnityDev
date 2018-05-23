using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool tap, swipeAny;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta {
        get {
            return swipeDelta;
        }
    }

    public bool SwipeAny {
        get {
            return swipeAny;
        }
    }

    private void Update()
    {

        tap = false;
        swipeAny = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {

            // Debug.Log("swiping!!");
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {

            isDragging = false;
            Reset();

        }

        #endregion


        #region Mobile Inputs

        if (Input.touches.Length > 0) {

            if (Input.touches[0].phase == TouchPhase.Began) {

                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;

            } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {

                isDragging = false;
                Reset();

            }

        }

        #endregion

        // Calculate Distance
        swipeDelta = Vector2.zero;

        if (isDragging) {

            if (Input.touches.Length > 0) {

                swipeDelta = Input.touches[0].position - startTouch;

            } else if (Input.GetMouseButton(0)) {

                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }

        }

        // Did we cross the deadzone?
        if (swipeDelta.magnitude > 125) {
            Debug.Log("Passed dead zone!");
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            swipeAny = true;

        }

    }

    private void Reset()
    {

        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDragging = false;
        
    }

}
