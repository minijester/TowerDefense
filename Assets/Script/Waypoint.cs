using UnityEngine;

public class Waypoint : MonoBehaviour {

    public static Transform[] points;

    private void Awake()
    {   // check child of waypoint transfrom
        points = new Transform[transform.childCount];
        for(int i =0;i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // get point from way point 
        }
    }
}
