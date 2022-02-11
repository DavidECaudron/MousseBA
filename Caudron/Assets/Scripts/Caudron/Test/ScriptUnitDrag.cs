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
        }
        // hold & drag
        if (Input.GetMouseButton(0))
        {
            _endPosition = Input.mousePosition;
            DrawVisual();
        }
        // release
        if (Input.GetMouseButtonUp(0))
        {
            _startPosition = Vector2.zero;
            _endPosition = Vector2.zero;
            DrawVisual();
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

    }
    private void SelectUnits()
    {

    }
}
