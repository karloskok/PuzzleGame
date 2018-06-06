using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level {

    public static bool Stamp(Element element, float target=1f)
   {
        element.stamp = true;
        element.timer = target;
        // element.animValue = Mathf.MoveTowards(element.animValue, target, speed/2 * Time.deltaTime);
        //Debug.Log(element.animValue);

        return !element.wasStamped;
    }

    public static void MoveTowards(Element element, float target, float speed=1F)
    {
        element.animValue = Mathf.MoveTowards(element.animValue, target, speed/2 * Time.deltaTime);
    }

    public static void SetWrapMode(Element element, WrapMode wrap)
    {
        element.wrapMode = wrap;
    }

    public static void SetAnimValue(Element element, float value)
    {
        element.animValue = value;
    }

    public static int GetCurrentHotspot(Element element, Hotspots hs)
    {
        float index = element.animValue / hs.value;
        index = Mathf.RoundToInt(index);

        //index = (int)index;
        //if (index >= hs.spots)
        //    index = --hs.spots;
        

        return (int) index;
    }

    public static void SetToHotspot(Element element, Hotspots hs, int index)
    {
        element.animValue = index * hs.value;
    }

    public static void MoveToHotspot(Element element, Hotspots hs, int index, float speed = 1f)
    {
        //if (index >= hs.spots)
        //    index = --hs.spots;
        

        element.animValue = Mathf.MoveTowards(element.animValue, index * hs.value, speed / 2 * Time.deltaTime); 
    }


    public enum MouseEvent
    {
        CLICK, DRAG, UPDATE
    };
    public static MouseEvent mouseEvent;


    public static void PushCamera(Transform camera, Transform newPosition, float moveSpeed = 1f)
    {
        /*
        camera.position = Vector3.Lerp(camera.position, newPosition.position, Time.deltaTime * moveSpeed);

        Vector3 currAngle = new Vector3(
            Mathf.LerpAngle(camera.eulerAngles.x, newPosition.transform.eulerAngles.x, Time.deltaTime * moveSpeed),
            Mathf.LerpAngle(camera.eulerAngles.y, newPosition.transform.eulerAngles.y, Time.deltaTime * moveSpeed),
            Mathf.LerpAngle(camera.eulerAngles.z, newPosition.transform.eulerAngles.z, Time.deltaTime * moveSpeed));

        camera.eulerAngles = currAngle;
        */
        camera.GetComponent<Camera>().enabled = false;
        newPosition.GetComponent<Camera>().enabled = true;
    }

}



public  class Hotspots
{
    public  int spots;

    public Hotspots(int spots)
    {
        this.spots = spots;
        value = 1F / --spots;
    }

    public float value;

    
}


