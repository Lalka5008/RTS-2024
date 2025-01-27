using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Camera mainCamera;
    public RectTransform selectionBoxUI;

    private SelectionHandler selectionHandler;
    private MovementHandler movementHandler;
    private SelectionBoxUIHandler selectionBoxUIHandler;
    private NoSelectionZoneHandler noSelectionZoneHandler;
    private UnitUIHandler unitUIHandler;


    private bool isSelecting = false;
    private Vector2 mouseDownPosition;
    private float movementThreshold = 5f; // ����� �������� ���� ��� ����������� ���������� �����
    private float clickTimer = 0f;
    private float clickMaxTime = 0.3f; // ������������ ����� ��� ���������� �����

    void Awake()
    {
        selectionHandler = gameObject.AddComponent<SelectionHandler>();
        movementHandler = gameObject.AddComponent<MovementHandler>();
        selectionBoxUIHandler = gameObject.AddComponent<SelectionBoxUIHandler>();
        noSelectionZoneHandler = gameObject.AddComponent<NoSelectionZoneHandler>();
        unitUIHandler = Object.FindFirstObjectByType<UnitUIHandler>();



        selectionBoxUIHandler.selectionBoxUI = selectionBoxUI;
        
    }

    void Update()
    {
        if (noSelectionZoneHandler.IsPointerOverNoSelectionZone())
        {
            isSelecting = false;
            return;
        }

        HandleSelection();
        movementHandler.HandleMovement(selectionHandler.GetSelectedUnits(), mainCamera);
    }

    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mouseDownPosition = Input.mousePosition;
            clickTimer = 0f;
        }

        if (Input.GetMouseButton(0) && isSelecting)
        {
            clickTimer += Time.deltaTime;
            if (clickTimer > clickMaxTime)
            {
                // ���� ����� ���������, �������� ��������� ����� �������
                if (!selectionBoxUIHandler.selectionBoxUI.gameObject.activeInHierarchy)
                {
                    selectionBoxUIHandler.StartSelection(mouseDownPosition);
                }
                else
                {
                    selectionBoxUIHandler.UpdateSelectionBox(Input.mousePosition);
                }
            }
            else
            {
                // ���������, �������� �� ����� ��������
                if (Vector2.Distance(mouseDownPosition, Input.mousePosition) > movementThreshold)
                {
                    // �������� ��������� ����� �������
                    if (!selectionBoxUIHandler.selectionBoxUI.gameObject.activeInHierarchy)
                    {
                        selectionBoxUIHandler.StartSelection(mouseDownPosition);
                    }
                    else
                    {
                        selectionBoxUIHandler.UpdateSelectionBox(Input.mousePosition);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isSelecting)
        {
            if (clickTimer <= clickMaxTime && Vector2.Distance(mouseDownPosition, Input.mousePosition) <= movementThreshold)
            {
                // ��� ��������� ����
                HandleSingleClick();
            }
            else
            {
                // ��� ��������� ����� �������
                selectionBoxUIHandler.EndSelection();
                SelectUnitsInBox();
            }
            isSelecting = false;
        }
    }

    void HandleSingleClick()
    {
        // ���������� ��� �� ������ � ����� �����
        Ray ray = mainCamera.ScreenPointToRay(mouseDownPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ���������, ����� �� ��� � ����
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Unit"))
            {
                // ���� ������ ������� Ctrl, ��������� ���� � ���������, ����� ������� ��������� � �������� ������ ���� ����
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    selectionHandler.SelectUnit(hitObject);
                }
                else
                {
                    selectionHandler.DeselectAllUnits();
                    selectionHandler.SelectUnit(hitObject);
                }

                // ��������� UI
                unitUIHandler.UpdateUI(selectionHandler.GetSelectedUnits());
            }
            else
            {
                // ���� ���� �� �� ����, ������� ���������
                selectionHandler.DeselectAllUnits();
                unitUIHandler.UpdateUI(selectionHandler.GetSelectedUnits());
            }
        }
    }

    void SelectUnitsInBox()
    {
        selectionHandler.DeselectAllUnits();

        Vector2 startMousePos = selectionBoxUIHandler.GetStartMousePos();
        Vector2 endMousePos = selectionBoxUIHandler.GetEndMousePos();

        Vector2 min = Vector2.Min(startMousePos, endMousePos);
        Vector2 max = Vector2.Max(startMousePos, endMousePos);

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x >= min.x && screenPos.x <= max.x &&
                screenPos.y >= min.y && screenPos.y <= max.y)
            {
                selectionHandler.SelectUnit(unit);
            }
        }

        // ��������� UI
        unitUIHandler.UpdateUI(selectionHandler.GetSelectedUnits());
    }
}