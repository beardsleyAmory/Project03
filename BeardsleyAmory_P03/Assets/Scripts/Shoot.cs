using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] AnimationClip _shootClip = null;
    [SerializeField] Animator _baseAnim = null;
    [SerializeField] GameObject _prefabPlort = null;
    [SerializeField] float _bulletVelocity = 2f;
    [SerializeField] GameObject _spout = null;
    [SerializeField] ParticleSystem _eject = null;
    [SerializeField] AudioSource _shootNoise = null;
    [SerializeField] AudioSource _recepNoise = null;

    public int StartInven = 20;
    private float _startPitch;

    //AnimationEvent evt = new AnimationEvent();
    

    private void Awake()
    {
        //_baseAnim.enabled = false;
        _baseAnim.SetInteger("Shoot", 0);
        ///evt.time = 0f;
       // evt.functionName = "ShootTheThing";

        // get the animation clip and add the AnimationEvent
        //_shootClip.AddEvent(evt);

        _startPitch = _recepNoise.pitch;
    }

    public void ShootStuff()
    {
        Debug.Log("Shooting");
        
        //ShootTheThing();
        RecoilAnimation();
        StartCoroutine("ShootTheThing");
        StartCoroutine("Noise");
        //play sounds and whatever
        
    }

    public void ResetAnim()
    {
        _baseAnim.SetInteger("Shoot", 0);
        StopAllCoroutines();
        _recepNoise.pitch = _startPitch;
    }

    IEnumerator Noise()
    {
        while (true)
        {
            _shootNoise.Play();

            yield return new WaitForSecondsRealtime(0.8f);
        }
    }

    IEnumerator ShootTheThing()
    {
        while (StartInven != 0)
        {
            //Debug.Log("Shot The Thing");
            GameObject currPlort = null;
            Vector3 currGun = new Vector3(_spout.transform.position.x, _spout.transform.position.y, _spout.transform.position.z + 0.2f);
            Rigidbody rb = null;

            currPlort = Instantiate(_prefabPlort, _spout.transform.position, _spout.transform.rotation);
            rb = currPlort.GetComponent<Rigidbody>();
            rb = currPlort.GetComponent<Rigidbody>();
            rb.AddForce(_spout.transform.forward * -1 * _bulletVelocity);

            _eject.Play();

            StartInven--;
            _recepNoise.pitch += 0.1f;

            yield return new WaitForSecondsRealtime(0.8f);
        }
    }

    private void RecoilAnimation()
    {
        _baseAnim.SetInteger("Shoot", 1);
    }
}
