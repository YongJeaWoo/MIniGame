using System.Collections;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [Header("ȭ�� ��� �ݶ��̴�")]
    [SerializeField] private Collider2D confinerBorder;

    private void Start()
    {
        StartCoroutine(WaitSpawnEnemiesCoroutine());
    }

    private void SpawnEnemies()
    {
        var obj = PlayerManager.Instance.GetPlayer().transform.GetChild(1);
        var spawner = obj.GetComponent<EnemySpawner>();
        spawner.GetCollider(this);
        spawner.StartSpawning();
    }

    private IEnumerator WaitSpawnEnemiesCoroutine()
    {
        yield return StageManager.Instance.FadeMethod(1, 0);
        yield return new WaitForSeconds(1f);
        SpawnEnemies();
    }

    public Collider2D GetConfinerBorder() => confinerBorder;
}
