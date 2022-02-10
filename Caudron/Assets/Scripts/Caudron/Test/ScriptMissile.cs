using UnityEngine;

[CreateAssetMenu(fileName = "NewMissile", menuName = "Missile")]
public class ScriptMissile : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
}
