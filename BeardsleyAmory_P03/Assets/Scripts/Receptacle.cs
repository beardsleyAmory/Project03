using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Receptacle : MonoBehaviour
{
    public event Action ReceptacleInput = delegate { };

    [SerializeField] ParticleSystem _stars = null;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered Receptacle");

        ReceptacleInput?.Invoke();
        other.gameObject.SetActive(false);
        _stars.Play();
    }
}
