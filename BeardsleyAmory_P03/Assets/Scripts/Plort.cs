using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plort : MonoBehaviour
{
    [SerializeField] AudioSource _hitSomethingNoise = null;

    private void OnCollisionEnter(Collision collision)
    {
        _hitSomethingNoise.Play();
    }
}
