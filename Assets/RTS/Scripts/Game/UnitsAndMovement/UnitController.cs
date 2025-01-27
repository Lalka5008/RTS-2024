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
    private float movementThreshold = 5f; // Порог движения мыши для определения одиночного клика
    private float clickTimer = 0f;
    private float clickMaxTime = 0.3f; // Максимальное время для одиночного клика

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
                // Если время превышено, начинаем выделение через область
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
                // Проверяем, превышен ли порог движения
                if (Vector2.Distance(mouseDownPosition, Input.mousePosition) > movementThreshold)
                {
                    // Начинаем выделение через область
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
                // Это одиночный клик
                HandleSingleClick();
            }
            else
            {
                // Это выделение через область
                selectionBoxUIHandler.EndSelection();
                SelectUnitsInBox();
            }
            isSelecting = false;
        }
    }

    void HandleSingleClick()
    {
        // Отправляем луч из камеры в точку клика
        Ray ray = mainCamera.ScreenPointToRay(mouseDownPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Проверяем, попал ли луч в юнит
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Unit"))
            {
                // Если зажата клавиша Ctrl, добавляем юнит к выделению, иначе снимаем выделение и выделяем только этот юнит
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    selectionHandler.SelectUnit(hitObject);
                }
                else
                {
                    selectionHandler.DeselectAllUnits();
                    selectionHandler.SelectUnit(hitObject);
                }

                // Обновляем UI
                unitUIHandler.UpdateUI(selectionHandler.GetSelectedUnits());
            }
            else
            {
                // Если клик не на юнит, снимаем выделение
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

        // Обновляем UI
        unitUIHandler.UpdateUI(selectionHandler.GetSelectedUnits());
    }
}