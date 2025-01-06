using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    #endregion

    [Header("���� �ð� ǥ��")]
    [SerializeField] private TextMeshProUGUI leftTimerText;

    public TextMeshProUGUI GetTimer() => leftTimerText;
    public string SetTimer(string value) => leftTimerText.text = value;
    public Color SetTimerColor(Color color) => leftTimerText.color = color;
}
