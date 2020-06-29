using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThruster = 100f;
    [SerializeField] float mainThruster = 100f;

    Rigidbody rigidbody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
        
    {
    Thrust();
    Rotate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
           
            {
            case "Friendly":
                break;
            case "Finish":
                print("Finish");
                SceneManager.LoadScene(1);
                break;
            default:
                print("crashed");
                SceneManager.LoadScene(0);
                break;

        }
    }
    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        float rotateThisFrame = rcsThruster * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward* rotateThisFrame);
        }
        rigidbody.freezeRotation = false;

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThruster);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {

            audioSource.Stop();

        }
    }
}
