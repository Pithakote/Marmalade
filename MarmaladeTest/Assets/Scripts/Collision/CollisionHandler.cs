using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Cars _car;
    [SerializeField] public CollisionBehaviour _behaviour; 
    private void Awake()
    {
        _car = GetComponent<Cars>();

        if (GetComponent<CollisionBehaviour>())
        {
            _behaviour = GetComponent<CollisionBehaviour>();
        }
        else
        {
            if (_car is PlayerCar)
            {
                _behaviour = gameObject.AddComponent<CollisionBehaviourPlayer>();
            }
            else
            {
                _behaviour = gameObject.AddComponent<CollisionBehaviourAI>();
            }
        }
        
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

        _behaviour.CollisionBehaviourAction(collision);
       
    }
}
