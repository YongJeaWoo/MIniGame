using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("�÷��̾� �⺻ ����")]
    [SerializeField] private float maxExp;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHp;

    [Header("���ݷ� ����")]
    [SerializeField] private float attackPoint;

    public float GetMaxHp() => maxHp;
    public float GetMoveSpeed() => moveSpeed;
    public float GetMaxExp() => maxExp;
    public float GetAttackPoint() => attackPoint;
}
