using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float targetAspect = 9.0f / 16.0f;

        float windowAspect = (float)Screen.width / (float)Screen.height;

        float scaleWidth =  windowAspect / targetAspect;

        Camera cam = GetComponent<Camera>();

        if (scaleWidth > 1.0f) {
            
            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;

        } else {
            float scaleHeight = 1.0f / scaleWidth;

            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;;

            cam.rect = rect;
            
        }
		
	}

}
