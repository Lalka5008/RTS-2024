using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class NoSelectionZoneHandler : MonoBehaviour
{
    // Метод для проверки, находится ли указатель над зоной без выделения
    public bool IsPointerOverNoSelectionZone()
    {
        PointerEventData eventDataCurrentPos = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPos, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("NoSelectionZone"))
            {
                Debug.Log("Pointer is over NoSelectionZone");
                return true;
            }
        }
        return false;
    }
}