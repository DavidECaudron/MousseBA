using UnityEngine;

[CreateAssetMenu(fileName ="Unit", menuName ="MOBA/Unit")]
public class UnitData : ScriptableObject
{
    public string Name;
    public int HP;
    public float MoveSpeed;
    public int Damage;
    public GameObject Graphic;
    public Resource[] RequiredResources;
}
