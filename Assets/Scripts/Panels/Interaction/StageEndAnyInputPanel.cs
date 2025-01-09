using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class StageEndAnyInputPanel : MonoBehaviour
{
    protected readonly string isOpenText = $"isOpen";

    [Header("���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI infoText;

    private bool isInputKey = false;

    private Animator animator;

    public event Action OnAnyInputKey;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(isOpenText, true);
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.anyKeyDown && !isInputKey)
        {
            isInputKey = true;
            StartCoroutine(RemovePopupCoroutine());
        }
    }

    protected IEnumerator RemovePopupCoroutine()
    {
        if (animator != null)
        {
            animator.SetBool(isOpenText, false);

            while (!IsAnimatorFinished(animator, "Close"))
            {
                yield return null;
            }
        }

        var parentName = transform.parent.name;
        OnAnyInputKey?.Invoke();

        PopupManager.Instance.RemovePopup(parentName);

        yield break;
    }

    protected bool IsAnimatorFinished(Animator animator, string name)
    {
        var anim = animator.GetCurrentAnimatorStateInfo(0);
        return anim.IsName(name) && anim.normalizedTime >= 1f;
    }

    public string SetInfoText(string value) => infoText.text = value;
}
