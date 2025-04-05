using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public ID id;
    public UnityEvent matchEvent, mismatchEvent;

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID.id == id)
        {
            matchEvent.Invoke();
            Debug.Log("Matched ID: " + id);
        }
        else
        {
            mismatchEvent.Invoke();
            Debug.Log("No Match ID: " + id);
        }
    }
}
