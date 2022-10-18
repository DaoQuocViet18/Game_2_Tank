using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_fly : MonoBehaviour
{
    public float Deadline = 2;

    // Start is called before the first frame update
    void Start()
    {
        Deadline += Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= Deadline)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
