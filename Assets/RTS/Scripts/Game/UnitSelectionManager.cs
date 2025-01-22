using UnityEngine;
using System.Collections.Generic;

public class UnitSelectionManager : MonoBehaviour
{
    public LayerMask unitLayer; // ���� ��� ������
    public RectTransform selectionBox; // RectTransform ��� ������������ selection box
    public List<GameObject> selectedUnits = new List<GameObject>(); // ������ ���������� ������

    private Vector2 startMousePos; // ��������� ������� ����
    private Vector2 endMousePos; // �������� ������� ����
    private bool isSelecting = false; // ���� ��� ������������ ��������� ���������
    private GameObject visualBox; // ��������� ������ ��� ������������

    void Start()
    {
        // ���������, ��� selectionBox �������� ��� ������
        selectionBox.gameObject.SetActive(false);

        // �������� ��������� ������ ��� ������������
        visualBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        visualBox.name = "SelectionVisualBox";
        visualBox.SetActive(false);
        Destroy(visualBox.GetComponent<Collider>()); // ������� ���������
        Material mat = new Material(Shader.Find("Transparent/Diffuse"));
        mat.color = new Color(1, 0, 0, 0.5f); // �������������� ������� ����
        visualBox.GetComponent<MeshRenderer>().material = mat;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
            isSelecting = true;
            selectionBox.gameObject.SetActive(true);
            selectionBox.sizeDelta = Vector2.zero; // ����� �������
            selectionBox.anchoredPosition = startMousePos; // ���������� ��������� �������
        }

        if (Input.GetMouseButton(0) && isSelecting)
        {
            endMousePos = Input.mousePosition;
            UpdateSelectionBox();
        }

        if (Input.GetMouseButtonUp(0) && isSelecting)
        {
            isSelecting = false;
            selectionBox.gameObject.SetActive(false);
            visualBox.SetActive(false); // ��������� ��������� ������
            SelectUnits();
        }
    }

    void UpdateSelectionBox()
    {
        float width = endMousePos.x - startMousePos.x;
        float height = endMousePos.y - startMousePos.y;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        // ���������� ������� selectionBox � ����� ����� startMousePos � endMousePos
        selectionBox.anchoredPosition = startMousePos + new Vector2(width / 2, height / 2);

        // �������� ��������� ������ ��� ������������
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        Vector3 minWorld = Camera.main.ScreenToWorldPoint(new Vector3(min.x, min.y, Camera.main.nearClipPlane));
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(new Vector3(max.x, max.y, Camera.main.nearClipPlane));

        visualBox.transform.position = (minWorld + maxWorld) / 2;
        visualBox.transform.localScale = maxWorld - minWorld;
        visualBox.SetActive(true);

        // �������: ����� �������� � ������� selectionBox
        Debug.Log("Selection Box Size: " + selectionBox.sizeDelta);
        Debug.Log("Selection Box Position: " + selectionBox.anchoredPosition);
        Debug.Log("Visual Box Position: " + visualBox.transform.position);
        Debug.Log("Visual Box Scale: " + visualBox.transform.localScale);
    }

    void SelectUnits()
    {
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        Vector3 minWorld = Camera.main.ScreenToWorldPoint(new Vector3(min.x, min.y, Camera.main.nearClipPlane));
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(new Vector3(max.x, max.y, Camera.main.nearClipPlane));

        Debug.Log("Selection Box Min: " + minWorld);
        Debug.Log("Selection Box Max: " + maxWorld);

        Collider[] colliders = Physics.OverlapBox((minWorld + maxWorld) / 2, (maxWorld - minWorld) / 2, Quaternion.identity, unitLayer);

        selectedUnits.Clear();
        foreach (Collider collider in colliders)
        {
            GameObject unit = collider.gameObject;
            Debug.Log("Checking unit: " + unit.name);
            if (unit.CompareTag("Unit"))
            {
                selectedUnits.Add(unit);
                Debug.Log("Selected unit: " + unit.name); // �������: ����� ����� ����������� �����
            }
        }

        if (selectedUnits.Count == 0)
        {
            Debug.Log("No units selected."); // �������: �����, ���� �� ���� ���� �� �������
        }


    }
}
