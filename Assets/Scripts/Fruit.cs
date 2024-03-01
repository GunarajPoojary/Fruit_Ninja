using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour 
{
	float startForce = 3f;

    Rigidbody rb;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(3, 6)) * startForce, ForceMode.Impulse);
		rb.AddTorque( new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), ForceMode.Impulse);
	}

    void OnTriggerEnter(Collider col)
	{
        if (GameManager.Instance.gameIsActive)
        {
            if (col.tag == "Blade")
            {
                Vector3 direction = (col.transform.position - transform.position).normalized;

                Quaternion rotation = Quaternion.LookRotation(direction).normalized;
                transform.rotation = rotation;
                transform.DetachChildren();
                GameManager.Instance.score += 5;
            }
        }
    }
}
