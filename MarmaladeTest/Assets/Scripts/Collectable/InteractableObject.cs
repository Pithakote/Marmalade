using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    public abstract void OnInteracted();
}
