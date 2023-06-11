using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarmaladeButton : MonoBehaviour
{
    [SerializeField] private GameObject _presenterGameObject;
    [SerializeField] private Button marmaladeButton;
    [SerializeField] private ButtonPressedBehaviour _marmaladeButtonBehaviour;
    private void Awake()
    {
        _marmaladeButtonBehaviour = GetComponent<ButtonPressedBehaviour>();

        marmaladeButton.GetComponent<Button>();
        marmaladeButton.onClick.AddListener(OnButtonPressed);
    }
    public void OnButtonPressed()
    {
        _marmaladeButtonBehaviour.OnPressed(_presenterGameObject);
    }
}
