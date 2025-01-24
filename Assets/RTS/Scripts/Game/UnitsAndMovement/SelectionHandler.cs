// SelectionHandler.cs
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    private List<GameObject> selectedUnits = new List<GameObject>();

    public void SelectUnit(GameObject unit)
    {
        selectedUnits.Add(unit);
        Transform selectionSprite = unit.transform.Find("SelectionSprite");
        if (selectionSprite != null)
        {
            selectionSprite.gameObject.SetActive(true);
        }
    }

    public void DeselectAllUnits()
    {
        foreach (GameObject unit in selectedUnits)
        {
            Transform selectionSprite = unit.transform.Find("SelectionSprite");
            if (selectionSprite != null)
            {
                selectionSprite.gameObject.SetActive(false);
            }
        }
        selectedUnits.Clear();
    }

    public List<GameObject> GetSelectedUnits()
    {
        return selectedUnits;
    }
}
