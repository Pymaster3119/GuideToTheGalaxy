using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StarPositionFromSphericalCoordinates : MonoBehaviour
{
    public float rahours;
    

    public float dechours;

    public float distance;
    public Vector3 position;

    public float radius;
    public int exponent;

    public float timer;
    public bool isenabled;

    public static GameObject popup;

    public float magnitude;

    public float pmra;
    public float pmdec;

    public float absolutemagnitude;
    // Start is called before the first frame update

   


    void ComputePosition()
    {
        //Convert RA from hours, minutes, seconds to degrees
        float nra = rahours;

        //Convert DEC from hours, minutes, seconds to degrees
        float ndec = dechours;

        //Convert both to radians
        nra = Mathf.Deg2Rad * nra;
        ndec = Mathf.Deg2Rad * ndec;



        ////Calculate our 3d position
        position.x = Mathf.Cos(ndec) * Mathf.Cos(nra);
        position.z = Mathf.Sin(nra);
        position.y = Mathf.Sin(ndec) * Mathf.Cos(nra);

        //position.x = Mathf.Cos(nra) * Mathf.Sin(ndec);
        //position.y = Mathf.Sin(ndec);
        //position.z = Mathf.Sin(nra) * Mathf.Sin(ndec);

        //Set Position
        transform.position = position * distance;

        
    }


    private void Start()
    {
        ComputePosition();
    }
}
