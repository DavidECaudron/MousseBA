using System.Collections.Generic;
using UnityEngine;

public class ScriptUnitSelection : MonoBehaviour
{
    public List<GameObject> UnitList = new List<GameObject>();
    public List<GameObject> UnitSelectedList = new List<GameObject>();

    public static ScriptUnitSelection Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        UnitSelectedList.Add(unitToAdd);
        // unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ShitClickSelect(GameObject unitToAdd)
    {
        if (!UnitSelectedList.Contains(unitToAdd))
        {
            UnitSelectedList.Add(unitToAdd);
            // unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            // unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            UnitSelectedList.Remove(unitToAdd);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if (!UnitSelectedList.Contains(unitToAdd))
        {
            UnitSelectedList.Add(unitToAdd);
            // unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void DeselectAll()
    {
        /*
        foreach (var item in _unitSelectedList)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
        */
        UnitSelectedList.Clear();
    }
    public void Deselect(GameObject unitToRemove)
    {

    }
}
