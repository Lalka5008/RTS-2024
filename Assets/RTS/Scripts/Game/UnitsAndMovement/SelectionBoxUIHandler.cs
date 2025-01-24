// SelectionBoxUIHandler.cs
using UnityEngine;

public class SelectionBoxUIHandler : MonoBehaviour
{
    public RectTransform selectionBoxUI;

    private Vector2 startMousePos;
    private Vector2 endMousePos;

    public void StartSelection(Vector2 startMousePos)
    {
        this.startMousePos = startMousePos;
        selectionBoxUI.gameObject.SetActive(true);
        selectionBoxUI.sizeDelta = Vector2.zero;
        selectionBoxUI.anchoredPosition = startMousePos;
    }

    public void UpdateSelectionBox(Vector2 currentMousePos)
    {
        endMousePos = currentMousePos;

        float width = endMousePos.x - startMousePos.x;
        float height = endMousePos.y - startMousePos.y;

        selectionBoxUI.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBoxUI.anchoredPosition = startMousePos + new Vector2(width / 2, height / 2);
    }

    public void EndSelection()
    {
        selectionBoxUI.gameObject.SetActive(false);
    }

    public Vector2 GetStartMousePos() => startMousePos;
    public Vector2 GetEndMousePos() => endMousePos;
}
