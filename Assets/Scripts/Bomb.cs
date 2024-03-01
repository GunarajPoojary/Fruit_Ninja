using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float startForce = 3f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(3, 6)) * startForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Blade")
        {
            Rigidbody bombRb = col.GetComponent<Rigidbody>();
            bombRb.isKinematic = true;

            GameManager.Instance.gameIsActive = false;
            GameManager.Instance.Lose();
        }
    }
}
