using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTP : MonoBehaviour
{

    GameObject Character;
    GameObject Camera;
    GameObject Helper;
    GameObject Target;
    //GameObject Fly;
    //GameObject Turn;
    Rigidbody rigid;
    Transform transP;
    Transform trans;
    Transform transC;
    Transform transH;
    Transform transT;
    //Transform transR;
    float zoom;
    float T;
    //float H;
    public static bool dead;
    RaycastHit hit;
    Vector3 vzoom;
    Vector3 vfly;


    void Start ()
    {
        T = 1.5f;
        zoom = 6f;        
        Character = GameObject.FindWithTag("Player");
        Camera = GameObject.FindWithTag("MainCamera");
        Helper = new GameObject("Helper");       
        Target = new GameObject("Target");        
        Target.transform.parent = Character.transform;
        Helper.transform.parent = Target.transform;    
        transP = Character.GetComponent<Transform>();
        transC = Camera.GetComponent<Transform>();
        transH = Helper.GetComponent<Transform>();
        transT = Target.GetComponent<Transform>();
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();        
        transT.position = transP.position + new Vector3(0f, 1.5f, 0f);
        transH.position = new Vector3(0f, 4f, 9f);     
        vzoom = transP.forward + new Vector3(0f,0.25f,0f);
        vfly = transH.position - trans.position;
    }

    void Update ()
    {  
        //TURN
        if (Input.GetAxis("Mouse X") < 0)
        {
            vzoom = Quaternion.AngleAxis(-2f, Vector3.up) * vzoom;
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            vzoom = Quaternion.AngleAxis(2f, Vector3.up) * vzoom;
        }
       

        //ZOOM
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 12f)
        {
            zoom = zoom + 0.25f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 1f)
        {
            zoom = zoom - 0.25f;
        }

        
        //AVOID OBJECTS
        Debug.DrawRay(transP.position + new Vector3(0f, 1f, 0f) + (vzoom.normalized * 0.25f), vzoom.normalized * (zoom * 0.8f), Color.red);        
        if (Physics.Raycast(transP.position + new Vector3(0f,1f,0f) + (vzoom.normalized * 0.25f), vzoom, out hit, (zoom * 0.8f)))
        {            
                transT.position = transP.position + new Vector3(0f, T, 0f);
                transH.position = transP.position + new Vector3(0f, 1f, 0f) + (vzoom.normalized * hit.distance);
                trans.position = transH.position;                         
        }
        else
        {   
        transT.position = transP.position + new Vector3(0f,T,0f);
        transH.position = transP.position + new Vector3(0f,1f,0f) + (vzoom.normalized * zoom);           
        }                        
        T = 1.5f - ((trans.position - (transP.position + new Vector3(0f, 1f, 0f))).magnitude * 0.125f);
        vfly = transH.position - trans.position;
        rigid.velocity = (vfly * 1f);      
        transC.position = trans.position;        
        transC.LookAt(transT);            
    }
}
