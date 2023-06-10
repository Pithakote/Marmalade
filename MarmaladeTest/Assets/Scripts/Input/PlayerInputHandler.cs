using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private bool _isClicked = false;
    [SerializeField] private Vector3 _mouseClickPosition = Vector3.zero;
    private Ray _mouseRay;
    private RaycastHit _mouseRayHit;
    public Vector3 MouseClickPosition { get { return _mouseClickPosition; } }
    public bool IsClicked { get { return _isClicked; } }

    private void Start()
    {
        _mainCamera = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //looked at the code form here https://www.youtube.com/watch?v=qA7WbcJmhUM&ab_channel=Devsplorer
            _isClicked = true;
            _mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_mouseRay, out _mouseRayHit))
            {
                _mouseClickPosition = _mouseRayHit.point;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isClicked = false;
        }
    }
}
