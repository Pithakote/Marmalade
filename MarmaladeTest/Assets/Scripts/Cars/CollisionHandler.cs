using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Cars _car;

    private void Awake()
    {
        _car = GetComponent<Cars>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding object is: " + collision.gameObject);
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            _car.ResetPosition();
            return;
        }

        if (collision.gameObject.GetComponent<MonoBehaviour>() == null)
        {
            return;
        }

        IInteractable interactable = collision.gameObject.GetComponent<MonoBehaviour>() as IInteractable;

        if (interactable != null)
        {
            interactable.OnInteracted();
        }
    }
}
