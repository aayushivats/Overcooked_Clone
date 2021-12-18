using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public float speed = 5.0f;
    public Animator anim;
    GameObject itemInHand=null;
    //Rigidbody rb;
    Vector3 playerInput;
    public float timer=0;
    public bool startTimer=false;
    public int score=0;
    // Start is called before the first frame update  
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastHit hit = GetRaycastResult();
            if (hit.collider != null)
            {
                var station = hit.transform.GetComponent<Station>();
                if (station)
                {
                    station.DoPickupDrop();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit hit = GetRaycastResult();
            if (hit.collider != null)
            {
                var station = hit.transform.GetComponent<Station>();
                if (station)
                {
                    station.DoChop();
                }
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5,Color.green);
        GetInput();
        if(startTimer==true)
        {
           
            timer +=Time.deltaTime;
        }
        if(timer>=2)
        {
            startTimer = false;
            timer = 0;
            StopCuttingAnimation();
        }
    }

    private RaycastHit GetRaycastResult()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5);

        return hit;
    }

    private void FixedUpdate()
    {
        transform.Translate(playerInput, Space.World);
        //GetInput();
    }
    private void GetInput()
    {
        playerInput = Vector3.zero;
        //Start Movement Code
        if (Input.GetKey(KeyCode.W))
        {
            //Vector3 m_Input = new Vector3((-1)*Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            playerInput+=(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerInput += (Vector3.left * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            //rb.MovePosition(transform.position + (-transform.right) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerInput += (Vector3.back * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
            //rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerInput += (Vector3.right * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            //rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        //End Movement Code
       
    }

    public void SetItem(GameObject item)
    {
        itemInHand = item;
    }

    public GameObject GetItem()
    {
        return itemInHand;
    }
    
    public void CutItem()
    {
        
        itemInHand.transform.position = transform.position + Vector3.forward * -3;
        
        startTimer = true;
        if(timer>2)
        {
            Debug.Log("Stop");
            startTimer = false;
            timer = 0;
            anim.SetBool("isCutting", false);
            
        }
        //GameObject go = Instantiate(hit.transform.gameObject, transform.position + Vector3.forward * 3, Quaternion.identity, transform);
       // go.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
       // go.GetComponent<Collider>().enabled = false;
    }

    public void StartCuttingAnimation()
    {
        startTimer = true;
        anim.SetBool("isCutting", true);
    }

    public void StopCuttingAnimation()
    {
        anim.SetBool("isCutting", false);

    }

}

