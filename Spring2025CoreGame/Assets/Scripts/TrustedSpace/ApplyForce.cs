using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;
    public int speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed);
        
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
