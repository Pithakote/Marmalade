using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonPressedBehaviour : MonoBehaviour
{
    [SerializeField] protected string SceneToChangeName;
    public abstract void OnPressed(GameObject presenterGameObject);
}
