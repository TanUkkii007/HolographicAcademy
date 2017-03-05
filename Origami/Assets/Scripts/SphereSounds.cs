using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSounds : MonoBehaviour
{
    AudioSource audioSource = null;
    AudioClip impactClip = null;
    AudioClip rollingClip = null;

    bool rollong = false;

    // Use this for initialization
    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 20f;

        impactClip = Resources.Load<AudioClip>("Impact");
        rollingClip = Resources.Load<AudioClip>("Rolling");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= 0.1f)
        {
            audioSource.clip = impactClip;
            audioSource.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rigid = this.gameObject.GetComponent<Rigidbody>();

        if (!rollong && rigid.velocity.magnitude >= 0.01f)
        {
            rollong = true;
            audioSource.clip = rollingClip;
            audioSource.Play();
        }
        else if (rollong && rigid.velocity.magnitude < 0.01f)
        {
            rollong = false;
            audioSource.Stop();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (rollong)
        {
            rollong = false;
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
