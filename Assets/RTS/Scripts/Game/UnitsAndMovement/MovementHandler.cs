using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public void HandleMovement(List<GameObject> selectedUnits, Camera mainCamera)
    {
        if (selectedUnits.Count > 0 && Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                foreach (GameObject unit in selectedUnits)
                {
                    UnitStopper unitController = unit.GetComponent<UnitStopper>();
                    if (unitController != null)
                    {
                        unitController.MoveTo(hit.point);
                    }
                }
            }
        }
    }
}   