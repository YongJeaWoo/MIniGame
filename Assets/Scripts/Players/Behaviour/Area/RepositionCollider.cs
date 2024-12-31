using UnityEngine;

public class RepositionCollider : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;

        var player = PlayerManager.Instance.GetPlayer();
        var movement = player.GetComponent<PlayerMovement>();

        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;

        Vector3 playerDir = movement.GetInputVector();

        // �÷��̾� ���⿡ ���� �̵� ���� ���
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        // ���ġ ���
        switch (transform.tag)
        {
            case "Ground":
                // X�� �̵�
                if (Mathf.Abs(diffX) > 20) // 20�� �ݶ��̴� �ݰ�
                {
                    transform.Translate(Vector3.right * dirX * 40); // 40�� �� ũ���� 2��
                }

                // Y�� �̵�
                if (Mathf.Abs(diffY) > 20)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }

                if (Mathf.Abs(diffX) > 20 && Mathf.Abs(diffY) > 20)
                {
                    Vector3 moveDirection = new Vector3(dirX, dirY, 0).normalized;  // �밢�� �̵��� ���� ���� ����
                    transform.Translate(moveDirection * 40); // �밢�� �̵�
                }
                break;
        }
    }
}
