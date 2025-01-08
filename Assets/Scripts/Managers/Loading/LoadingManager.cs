using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [Header("�ε� �̹���")]
    [SerializeField] private Image loadingFillImage;
    [Header("�ε� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI loadingText;
    [Header("�ε� �ۼ�Ʈ �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI percentText;

    private static string nextSceneName;
    private const string loadingSceneName = "Loading";

    private float fakeProgress = 0f;
    private const float smoothingSpeed = 0.3f;

    private bool isAlmostDone = false;
    private bool isLoadingAnimation = true;

    public static void LoadScene(string sceneName)
    {
        nextSceneName = sceneName;
        SceneManager.LoadScene(loadingSceneName);
    }

    private void Start()
    {
        StartCoroutine(DelayStartCoroutine());
        StartCoroutine(LoadingTextAnimationCoroutine());
    }

    private IEnumerator DelayStartCoroutine()
    {
        float delayTime = Mathf.Lerp(1.0f, 1.5f, Mathf.InverseLerp(0f, 1f, fakeProgress)); 
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(LoadAsync(nextSceneName));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        yield return new WaitForEndOfFrame();

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        //ToggleGUI();

        while (!op.isDone)
        {
            float realProgress = Mathf.Clamp01(op.progress / 0.9f);

            fakeProgress = Mathf.SmoothStep(fakeProgress, realProgress, Time.unscaledDeltaTime * smoothingSpeed);
            loadingFillImage.fillAmount = fakeProgress;

            string pText = $"{Mathf.FloorToInt(fakeProgress * 100):D2}%";
            percentText.text = pText;

            if(fakeProgress >= 0.99f && !isAlmostDone)
            {
                isAlmostDone = true;
                loadingText.text = "�ε� �Ϸ�!";
                isLoadingAnimation = false;  // �ִϸ��̼� ����
            }

            if (fakeProgress < 1f)
            {
                fakeProgress = Mathf.MoveTowards(fakeProgress, 1f, Time.unscaledDeltaTime * smoothingSpeed * 0.5f);
            }

            if (fakeProgress >= 1f)
            {
                fakeProgress = 1f;
                percentText.text = "100%"; 

                yield return new WaitForSeconds(1f); 

                op.allowSceneActivation = true;  
            }

            yield return null;
        }
    }

    private IEnumerator LoadingTextAnimationCoroutine()
    {
        string baseText = $"�ε� ��";
        int dotCount = 0;

        while (isLoadingAnimation)
        {
            dotCount = (dotCount + 1) % 4;

            loadingText.text = baseText + new string('.', dotCount);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ToggleGUI()
    {
        // UI ���ſ�
    }
}
