using System;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.GetComponent<GeometryObjectModel>())
            {
                Clicked?.Invoke();
            }
        }
    }
}
