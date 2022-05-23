using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour
{

    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/

    [SerializeField]
    public GameObject target;

    public float targetTranslateSpeed = 0.02f;
    public float mainSpeed = 100.0f; //regular speed
    public float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    public float maxShift = 1000.0f; //Maximum speed when holdin gshift
    public float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;


    void Update()
    {


        
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0)
        { // only move while a direction key is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;

            transform.Translate(p);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            target.transform.Translate(target.transform.up * targetTranslateSpeed*Time.deltaTime);
            transform.Translate(target.transform.up * targetTranslateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            target.transform.Translate(-target.transform.up * targetTranslateSpeed*Time.deltaTime);
            transform.Translate(-target.transform.up * targetTranslateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            target.transform.Translate(-target.transform.right* targetTranslateSpeed * Time.deltaTime);
            transform.Translate(target.transform.right * targetTranslateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            target.transform.Translate(target.transform.right * targetTranslateSpeed * Time.deltaTime);
            transform.Translate(target.transform.right * targetTranslateSpeed * Time.deltaTime);
        }

        transform.LookAt(target.transform);
        //Mouse  camera angle done.  
    }


    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.Z))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }

        return p_Velocity;
    }
}