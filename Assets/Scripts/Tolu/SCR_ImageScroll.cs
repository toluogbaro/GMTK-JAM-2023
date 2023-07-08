using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ImageScroll : MonoBehaviour
{
    public GameObject imageScroller;
    public List<Vector3> imagePos;
    public float scrollSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ScrollToImage(imagePos[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ScrollToImage(imagePos[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ScrollToImage(imagePos[2]);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ScrollToImage(imagePos[3]);
    }

    void ScrollToImage(Vector3 imageLocation)
    {
        LeanTween.moveLocal(imageScroller, imageLocation, scrollSpeed).setEaseInBack();

    }
}
