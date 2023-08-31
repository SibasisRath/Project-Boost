using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioClip launch;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem rightSideThrustParticles;
    [SerializeField] ParticleSystem leftSideThrustParticles;

    AudioSource audioSource;

    private Rigidbody _rigidBody;
    private float _horizntalInput;
    
    // Start is called before the first frame update
    void Start()
    {      
        _rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
  
    }

    // Update is called once per frame
    void Update()
    {
        RotateWork();


        if (Input.GetKey(KeyCode.Space))
        {
            
            ThrustWork();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(launch);
            }
            if (!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            mainThrustParticles.Stop();
            audioSource.Stop();
        }
    }

    private void ThrustWork()
    {
        _rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * speed);
    }

    private void RotateWork()
    {
        _horizntalInput = Input.GetAxis("Horizontal");
        _rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * _horizntalInput * -1);
        if (_horizntalInput>0 )
        {
            leftSideThrustParticles.Play();
        }
        else if (_horizntalInput<0 )
        {
            rightSideThrustParticles.Play();
        }
        else
        {
            rightSideThrustParticles.Stop();
            leftSideThrustParticles.Stop();
        }
        _rigidBody.freezeRotation = false;
    }
}
