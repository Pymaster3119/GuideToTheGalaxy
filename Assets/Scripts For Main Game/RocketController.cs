
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class RocketController : MonoBehaviour
{
    public float speed;
    public float impulse;
    public float warp;
    public float renderspace;
    public float rotationalspeed;

    public float ra;
    public float dec;
    public float scrollspeed;
    Vector3 lpos;
    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Camera>().fieldOfView = 60;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Camera>().fieldOfView += Input.GetAxis("Scroll")*Time.deltaTime * scrollspeed;
        if (GetComponent<Camera>().fieldOfView > 90)
        {
            GetComponent<Camera>().fieldOfView = 90;
        }
        transform.Translate(0, 0, speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.Self);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = warp;
        }
        else
        {
            speed = impulse;
        }

        ra += Input.GetAxis("Horizontal") * Time.deltaTime * rotationalspeed;
        if (!(dec > 90 && Input.GetAxis("Vertical") > 0) && !(dec < -90 && Input.GetAxis("Vertical") < 0))
        {
            dec += Input.GetAxis("Vertical") * Time.deltaTime * rotationalspeed;
        }

        
        float nra = Mathf.Deg2Rad * ra;
        float ndec = Mathf.Deg2Rad * dec;

        Vector3 lpos = Vector3.zero;

        lpos.x = Mathf.Cos(ndec) * Mathf.Cos(nra);
        lpos.z = Mathf.Sin(nra);
        lpos.y = Mathf.Sin(ndec) * Mathf.Cos(nra);

        transform.LookAt(lpos + transform.position);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

    }

    private void FixedUpdate()
    {
        
    }
}
