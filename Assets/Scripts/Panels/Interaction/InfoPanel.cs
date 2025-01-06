using TMPro;
using UnityEngine;

public class InfoPanel : InteractionPanel
{
    [Header("���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI infoText;

    public string SetInfoText(string value) => infoText.text = value;
}
