using UnityEngine;

public abstract class MovementParent : MonoBehaviour
{
    [Header("�÷��̾� ������ �ӵ�")]
    [SerializeField] protected float moveSpeed;

    [Header("�׸��� ������")]
    [SerializeField] protected Vector2 shadowOffset;

    protected Vector2 direction;

    protected Rigidbody2D rigid;
    protected HealthParent health;

    protected virtual void Awake()
    {
        GetComponents();
    }

    protected virtual void GetComponents()
    {
        rigid = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthParent>();
    }

    protected void FixedUpdate()
    {
        ObjectMovement();
    }

    protected bool DontMove()
    {
        if (StageManager.Instance.GetIsStageEnd() || health.GetIsDead())
        {
            GetDontMove();
            return true;
        }

        return false;
    }

    protected abstract void ObjectMovement();

    public Vector2 GetInputVector() => direction.normalized;
    public Vector2 GetDontMove() => direction = Vector2.zero;
    public Vector2 GetShadowOffset() => shadowOffset;
}
