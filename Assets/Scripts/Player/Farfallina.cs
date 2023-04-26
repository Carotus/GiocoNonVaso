using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farfallina : MonoBehaviour
{
    public float offset;


    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 difference = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
