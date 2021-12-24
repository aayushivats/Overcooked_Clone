using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public float speed = 5.0f;
    public Animator anim;
    GameObject itemInHand=null;
    Rigidbody rb;
    Vector3 playerInput;
    public float timer=0;
    public bool startTimer=false;

    //Controls
    public string pickInput = "PickupDropP1";
    public string chopInput = "ChopP1";
    public string horizontalInput = "HorizontalP1";
    public string verticalInput = "VerticalP1";

    // Start is called before the first frame update  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetButtonDown(pickInput))
        {
            RaycastHit hit = GetRaycastResult();
            if (hit.collider != null)
            {
                var station = hit.transform.GetComponent<Station>();
                if (station)
                {
                    station.DoPickupDrop(transform);
                }
            }
        }
        else if (Input.GetButtonDown(chopInput))
        {
            RaycastHit hit = GetRaycastResult();
            if (hit.collider != null)
            {
                var station = hit.transform.GetComponent<Station>();
                if (station)
                {
                    station.DoChop(transform);
                }
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5,Color.green);
        Move();
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

    private void Move()
    {
        playerInput = Vector3.zero;
        //Start Movement Code
        playerInput += Input.GetAxis(horizontalInput) * Vector3.right;
        playerInput += Input.GetAxis(verticalInput) * Vector3.forward;

        playerInput.Normalize();

        rb.MovePosition(transform.position + playerInput * Time.deltaTime * speed);

        if (playerInput.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(playerInput, Vector3.up);
        }
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

