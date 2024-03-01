using Unity.VisualScripting;
using UnityEngine;

public class ObjectRepel : MonoBehaviour
{
    float repulsionForce = 5f;
    private Rigidbody rb;
    Transform objectToRepel;
    BoxCollider boxCol;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (transform.parent == null)
        {
            if (rb == null)
            {
                boxCol.enabled = true;
                rb = transform.AddComponent<Rigidbody>();
            }
        }
    }

    void Repel(Transform objectToRepel)
    {
        Vector3 direction = objectToRepel.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();
        float repulsionMagnitude = repulsionForce / (distance * distance);
        rb.AddForce(-direction * repulsionMagnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        objectToRepel = collision.transform;

        try
        {
            Repel(objectToRepel);
        }
        catch (MissingReferenceException)
        {
            Debug.Log(transform.name);
        }
    }
}
