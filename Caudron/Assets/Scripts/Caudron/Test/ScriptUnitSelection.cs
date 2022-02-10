using System.Collections.Generic;
using UnityEngine;

public class ScriptUnitSelection : MonoBehaviour
{
    public List<GameObject> _unitList = new List<GameObject>();
    public List<GameObject> _unitSelectedList = new List<GameObject>();

    private static ScriptUnitSelection _instance;
    public static ScriptUnitSelection Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        _unitSelectedList.Add(unitToAdd);
    }
    public void ShitClickSelect(GameObject unitToAdd)
    {
        if (!_unitSelectedList.Contains(unitToAdd))
        {
            _unitSelectedList.Add(unitToAdd);
        }
        else
        {
            _unitSelectedList.Remove(unitToAdd);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {

    }
    public void DeselectAll()
    {
        _unitSelectedList.Clear();
    }
    public void Deselect(GameObject unitToRemove)
    {

    }
}
