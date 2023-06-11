using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CollisionHandler))]
public abstract class Cars : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 2.0f;

    [Header("Scene objects")]
    [SerializeField] Vector3 _transformRespawnPoint;
    protected virtual void Awake()
    {
        _transformRespawnPoint = transform.position;

        if (GetComponent<Rigidbody>())
        {
            _rb = GetComponent<Rigidbody>();
        }
        else
        { 
            _rb = gameObject.AddComponent<Rigidbody>();
        }

        //wanted this to be kinematic but leaving it as non kinematic for this test
        //_rb.isKinematic = true;
    }


    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        _rb.MovePosition(transform.position + (Time.deltaTime * _moveSpeed * transform.forward)); //moving forward
    }

    public virtual void ResetPosition()
    {
        _rb.Sleep();
        transform.position = _transformRespawnPoint;
    }
}
