using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Receptacle : MonoBehaviour
{
    public event Action ReceptacleInput = delegate { };

    [SerializeField] ParticleSystem _stars = null;
    [SerializeField] AudioSource _receiveNoise = null;
    [SerializeField] HUDController _hud = null;

    public int MoneyAdd = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered Receptacle");

        ReceptacleInput?.Invoke();
        other.gameObject.SetActive(false);
        _stars.Play();
        _receiveNoise.Play();
        MoneyAdd += 36;
    }
}
