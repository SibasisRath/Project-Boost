using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundSound : MonoBehaviour
{
    [SerializeField] AudioClip drop;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.GetComponent<AudioSource>().PlayOneShot(drop);
        }
        
    }
}
