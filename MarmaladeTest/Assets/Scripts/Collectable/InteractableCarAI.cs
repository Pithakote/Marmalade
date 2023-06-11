using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCarAI : InteractableObject
{
    public override void OnInteracted()
    {
        Destroy(this.gameObject);
    }
}
