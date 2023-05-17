using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public LayerMask LayerHit;

    private int FarfallinaSpeed = 25;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    public Transform Belen;

    public float RotationPerSecond = 90.0f;

    [SerializeField] private GameObject grabbedObject;

   

    void Start()
    {
    }

    void Update()
    {
        // rotate grabbed obj
        if (Input.GetButton("Fire2"))
        {
            RotateGrabbedObject();
        }

        //grab object
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayPoint.transform.forward, rayDistance, LayerHit);
            if (hitInfo.collider != null)
            {
                Debug.Log("hit object " + hitInfo.collider.gameObject.layer);
                if (grabbedObject == null)
                {
                    grabbedObject = hitInfo.collider.gameObject;
                    var rb2d = grabbedObject.GetComponent<Rigidbody2D>();
                    
                    if (rb2d != null)
                    {
                        rb2d.isKinematic = true;
                        rb2d.simulated = false;
                        grabbedObject.transform.position = grabPoint.position;
                        grabbedObject.transform.SetParent(grabPoint.transform);
                        grabbedObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);                        
                    }
                }
            } else if(grabbedObject != null)
            {
                var rb2d = grabbedObject.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    Debug.Log("release obj");
                    rb2d.isKinematic = false;
                    rb2d.simulated = true;
                    grabbedObject.transform.parent = null;
                    grabbedObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                }
                grabbedObject = null;
            }
        }
    }

    void RotateGrabbedObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.Rotate(0, 0, RotationPerSecond * Time.deltaTime);
        }        
    }
}