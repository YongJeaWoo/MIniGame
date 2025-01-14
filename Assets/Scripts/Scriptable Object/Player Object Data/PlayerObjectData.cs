using UnityEngine;

[CreateAssetMenu(fileName = "Selected Data")]
public class PlayerObjectData : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Sprite selectedImage;

    [Header("ĳ���� ����")]
    [TextArea(5, 8)]
    [SerializeField] private string explain;

    public string GetPlayerName() => playerName;
    public string GetExplain() => explain;
    public Sprite GetSelectedImage() => selectedImage;
    public GameObject GetPlayerPrefab() => playerPrefab;
}
