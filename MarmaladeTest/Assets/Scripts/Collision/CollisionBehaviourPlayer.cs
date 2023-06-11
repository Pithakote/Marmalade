using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionBehaviourPlayer : CollisionBehaviour
{
    public override void CollisionBehaviourAction(Collision collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<MonoBehaviour>() as IInteractable;

        if (interactable != null)
        {
            interactable.OnInteracted();
        }
    }
}
