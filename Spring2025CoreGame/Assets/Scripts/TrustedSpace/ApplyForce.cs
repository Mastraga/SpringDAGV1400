using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 500);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnCollisionEnter(Collision hitbox)
    {
        Debug.Log("Collision detected with " + hitbox.gameObject.name);
    }
}
