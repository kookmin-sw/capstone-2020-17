using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonPeople : MonoBehaviour
{    
    Animator anim;
    Rigidbody rigid;
    Rigidbody rig;
    Transform trans;
    float jumpforce;
    bool gr;
    Vector3 v3VelocityAUX;
    Vector3 forcedir;
    RaycastHit hit;
    RaycastHit hit2;
    bool active;
    float run;
    float walk;
    float randomTime;
    float timeCounter;
    float fallCounter;
    



    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        jumpforce = 100f;
        forcedir = new Vector3(1f, 0f, 0f);
        active = true;
        randomTime = 3f;
        timeCounter = 0f;
        fallCounter = 0f;
        anim.SetInteger("idle", 300);      
    }


    void FixedUpdate()
    {           
        //IDLES
        if (timeCounter > randomTime)
        {
            anim.SetInteger("idle", Random.Range(0, 1200));
            randomTime = Random.Range(1, 12);
            timeCounter = 0f;
        }
        timeCounter += Time.deltaTime;


        //CHECK GROUNDED       
        if (Physics.Raycast(trans.position + new Vector3(0.18f, 0.05f, 0.15f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(0.18f, 0.05f, -0.15f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(-0.18f, 0.05f, 0.15f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(-0.18f, 0.05f, -0.15f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(0f, 0.05f, 0f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(-0.087f, 0.075f, 0f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(0.087f, 0.075f, 0f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(0f, 0.075f, -0.08f), Vector3.down, 0.085f)
                || Physics.Raycast(trans.position + new Vector3(0f, 0.075f, 0.08f), Vector3.down, 0.085f))
        {
            anim.SetBool("grounded", true);
            gr = true;
            fallCounter = 0f;           
        }
        else
        {
            anim.SetBool("grounded", false);
            gr = false;
            fallCounter += Time.deltaTime;
        }        


        // SET THE FORCE DIRECTION       
        if (Physics.Raycast(trans.position + new Vector3(0f, 0.05f, 0f), Vector3.down, out hit))
        {
            forcedir = -Vector3.Cross(Vector3.Cross(hit.normal, trans.forward), hit.normal);
            forcedir.Normalize();
        }


        //TRANSLATE
        anim.SetFloat("walk", Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.W) && gr == true && active == true)
        {
            rigid.velocity = forcedir * -1.35f * ((run*0.25f)+1f);            
        }
        else if (Input.GetKey(KeyCode.S) && gr == true && active == true )
        {
            rigid.velocity = forcedir * 1.35f * ((run * 0.1f) + 1f);            
        }
        

        //RUN
        if (Input.GetKey(KeyCode.LeftShift) && run < 10f)
            run = run + 0.25f;
        else if (run > 0f) run = run - 0.25f;
        anim.SetFloat("run", run);


        //TURN       
        if (Input.GetKey(KeyCode.D) && gr == true && active == true)
        {
            trans.Rotate(new Vector3(0f, 3f, 0f));
            if (anim.GetFloat("walk") == 0f)
                anim.SetInteger("turn", 1);
        }
        else
        {
            if (Input.GetKey(KeyCode.A) && gr == true && active == true)
            {
                trans.Rotate(new Vector3(0f, -3f, 0f));
                if (anim.GetFloat("walk") == 0f)
                    anim.SetInteger("turn", -1);
            }
            else anim.SetInteger("turn", 0);
        }


        //JUMP
        if (Input.GetKeyDown(KeyCode.Space) && gr == true && active == true)
        {
            active = false;
            
            if (anim.GetFloat("run")<=5f )
            {
                anim.Play("jumpin");
                rigid.AddForce(new Vector3(0f, 1f, 0f) * jumpforce * 1.55f, ForceMode.Acceleration);
            }      
            if (anim.GetFloat("run") >5f)          
            {
                anim.Play("jumprunin");
                rigid.AddForce((trans.forward * 0.07f + new Vector3(0f, 2.5f, 0f)) * jumpforce, ForceMode.Acceleration);
            }
                
        }

       
        //SITDOWN        
        if (anim.GetBool("sitdown") == true && Input.anyKeyDown) anim.SetBool("sitdown", false);
        if (Input.GetKeyDown(KeyCode.C) && gr == true && active == true && run == 0f)
        {
            if (Physics.Raycast(trans.position + new Vector3(0.0f, 0.3f, 0f) - trans.forward * 0.1f, -trans.forward, 0.17f)
                && !Physics.Raycast(trans.position + new Vector3(0.0f, 0.42f, 0f) - trans.forward * 0.1f, -trans.forward, 0.4f))
            {
                anim.SetBool("sitdown", true);
                anim.Play("sitdown");
                active = false;
            }
            else if (anim.GetFloat("walk") == 0f)
            {
                anim.Play("lookback");
                active = false;
            }
        }      
        

        //HITS       
        if (Physics.Raycast(trans.position + new Vector3(-0.2f, 0.35f, 0f), trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(-0.2f, 1f, 0f), trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(0.2f, 0.35f, 0f), trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(0.2f, 1f, 0f), trans.forward, out hit2, 0.33f))
        {
            if (hit2.transform.tag == "damage")
            {
                rigid.AddForce(trans.forward * -5f, ForceMode.Impulse);
                active = false;
                anim.Play("fall2");
            }
        }
        if (Physics.Raycast(trans.position + new Vector3(-0.2f, 0.35f, 0f), -trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(-0.2f, 1f, 0f), -trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(0.2f, 0.35f, 0f), -trans.forward, out hit2, 0.33f)
             || Physics.Raycast(trans.position + new Vector3(0.2f, 1f, 0f), -trans.forward, out hit2, 0.33f))
        {
            if (hit2.transform.tag == "damage")
            {
                rigid.AddForce(trans.forward * 5f, ForceMode.Impulse);
                active = false;
                anim.Play("fall1");
            }
        }


        //RESTART
        if (Input.GetKeyDown(KeyCode.P))
        {           
            CameraTP.dead = false;
            trans.position = (new Vector3(0f, 0.1f, 0f));
            trans.localRotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = (new Vector3(0f, 0f, 0f)); 
            anim.Play("static");
            anim.SetFloat("walk", 0f);
            anim.SetFloat("run", 0f);
            active = true;
            GetComponent<Collider>().enabled = true;
            anim.enabled = true;
            rigid.isKinematic = false;
            fallCounter = 0f;
        }
    }
      




    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }


}