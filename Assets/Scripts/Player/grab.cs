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
    public float rotationSpeed = 10f;
    public KeyCode rotateKey = KeyCode.R;

    void Start()
    {
    }

    void Update()
    {
        //grab object
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Click here mtfck!!!");
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
                        if (Input.GetKey(rotateKey))
                        {
                            float rotationAmount = rotationSpeed * Time.deltaTime;
                            transform.Rotate(Vector3.up, rotationAmount);
                        }
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
}