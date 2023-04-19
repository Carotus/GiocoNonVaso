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

    private GameObject grabbedObject;


    void Start()
    {
    }

    void Update()
    {
        //grab object
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Click here mtfck!!!");
            RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayPoint.transform.right, rayDistance, LayerHit);
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
                        grabbedObject.transform.position = grabPoint.position;
                        grabbedObject.transform.SetParent(grabPoint.transform);
                    }
                }
                else
                {
                    var rb2d = grabbedObject.GetComponent<Rigidbody2D>();
                    if (rb2d != null)
                    {
                        rb2d.isKinematic = false;
                        grabbedObject.transform.parent = null;
                    }
                    grabbedObject = null;
                }
            }
        }
    }
}