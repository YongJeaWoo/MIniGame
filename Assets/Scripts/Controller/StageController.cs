using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [Header("ȭ�� ��� �ݶ��̴�")]
    [SerializeField] private Collider2D confinerBorder;
    [Header("ȭ�� ���̵� �ƿ�")]
    [SerializeField] private Image fadeImage;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var obj = PlayerManager.Instance.GetPlayer().transform.GetChild(1);
        var spawner = obj.GetComponent<EnemySpawner>();
        spawner.GetCollider(this);
        spawner.StartSpawning();
    }

    public Collider2D GetConfinerBorder() => confinerBorder;
}
