using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Animation _recoilAnim = null;
    [SerializeField] Animator _baseAnim = null;
    [SerializeField] GameObject _prefabPlort = null;
    [SerializeField] float _bulletVelocity = 2f;
    [SerializeField] GameObject _spout = null;

    private void Awake()
    {
        _baseAnim.enabled = false;
    }

    public void ShootStuff()
    {
        Debug.Log("Shooting");

        GameObject currPlort = null;
        Vector3 currGun = new Vector3(_spout.transform.position.x, _spout.transform.position.y, _spout.transform.position.z + 0.2f);
        Rigidbody rb = null;

        currPlort = Instantiate(_prefabPlort, _spout.transform.position, _spout.transform.rotation);
        //currPlort.transform.position = currGun;
        rb = currPlort.GetComponent<Rigidbody>();
        rb = currPlort.GetComponent<Rigidbody>();
        rb.AddForce(_spout.transform.forward * -1 * _bulletVelocity);
        //start recoil animation
        _baseAnim.enabled = true;
        _baseAnim.Play("Shoot", -1, 0f);
        //play sounds and whatever
    }
}
