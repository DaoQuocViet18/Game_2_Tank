using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot_bullets : MonoBehaviour
{
    public Transform shoot_position;
    public GameObject bullet;
    private AudioSource playerAudio;
    public AudioClip shoot_sound;

    public float recovery_time_1 = 1;
    public float recovery_time_2 = 1;
    public float limt_time = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && transform.name == "Player_1" && Time.time >= recovery_time_1)
        {
            playerAudio.PlayOneShot(shoot_sound);
            Shoot();
            recovery_time_1 = Time.time + limt_time;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && transform.name == "Player_2" && Time.time >= recovery_time_2)
        {
            playerAudio.PlayOneShot(shoot_sound);
            Shoot();
            recovery_time_2 = Time.time + limt_time;
        }

        //Debug.DrawRay(shoot_position.position, transform.forward * 30, Color.green);
    }

    void Shoot()
    {
        GameObject current_bullet = Instantiate(bullet, shoot_position.position, bullet.transform.rotation);

        Rigidbody projectleRb = current_bullet.GetComponent<Rigidbody>();
        projectleRb.AddForce(transform.forward * 100, ForceMode.Impulse);
    }

}
