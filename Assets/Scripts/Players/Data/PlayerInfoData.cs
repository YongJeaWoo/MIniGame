using UnityEngine;

public class PlayerInfoData : MonoBehaviour
{
    [Header("�÷��̾� ������")]
    [SerializeField] private PlayerData playerData;

    public PlayerData GetPlayerData() => playerData;
}
