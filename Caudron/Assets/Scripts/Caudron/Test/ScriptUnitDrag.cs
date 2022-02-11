using UnityEngine;

public class ScriptUnitDrag : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _boxVisual;

    Rect _selectionBox;
    Vector2 _startPosition;
    Vector2 _endPosition;

    private void Start()
    {
        _startPosition = Vector2.zero;
        _endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        // click
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
            _selectionBox = new Rect();
        }
        // hold & drag
        if (Input.GetMouseButton(0))
        {
            _endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        // release
        if (Input.GetMouseButtonUp(0))
        {
            _startPosition = Vector2.zero;
            _endPosition = Vector2.zero;
            DrawVisual();
            SelectUnits();
        }
    }

    private void DrawVisual()
    {
        Vector2 _boxStart = _startPosition;
        Vector2 _boxEnd = _endPosition;

        Vector2 _boxCenter = (_boxStart + _boxEnd) / 2;
        _boxVisual.position = _boxCenter;

        Vector2 _boxSize = new Vector2(Mathf.Abs(_boxStart.x - _boxEnd.x), Mathf.Abs(_boxStart.y - _boxEnd.y));

        _boxVisual.sizeDelta = _boxSize;
    }
    private void DrawSelection()
    {
        // x selection
        if (Input.mousePosition.x < _startPosition.x)
        {
            // drag left
            _selectionBox.xMin = Input.mousePosition.x;
            _selectionBox.xMax = _startPosition.x;
        }
        else
        {
            // drag right
            _selectionBox.xMin = _startPosition.x;
            _selectionBox.xMax = Input.mousePosition.x;
        }
        // y selection
        if (Input.mousePosition.y < _startPosition.y)
        {
            // drag up
            _selectionBox.yMin = Input.mousePosition.y;
            _selectionBox.yMax = _startPosition.y;
        }
        else
        {
            // drag down
            _selectionBox.yMin = _startPosition.y;
            _selectionBox.yMax = Input.mousePosition.y;
        }
    }
    private void SelectUnits()
    {
        // loop through units
        foreach (var item in ScriptUnitSelection.Instance._unitList)
        {
            if (_selectionBox.Contains(_camera.WorldToScreenPoint(item.transform.position)))
            {
                ScriptUnitSelection.Instance.DragSelect(item);
            }
        }
    }
}
