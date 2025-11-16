using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider fadeSlider;
    public Image targetImage;
    public Image targetImage2;
    public Image targetImage3;

    [Header("Fade Settings")]
    public float fadeDuration = 0.3f;

    private float currentAlpha1 = 1f;
    private float currentAlpha2 = 0f;
    private float currentAlpha3 = 0f;

    private float targetAlpha1 = 1f;
    private float targetAlpha2 = 0f;
    private float targetAlpha3 = 0f;

    private string currentOption = "so"; // Tracks which option is currently selected

    void Start()
    {
        if (fadeSlider != null)
        {
            fadeSlider.onValueChanged.AddListener(OnSliderValueChanged);
            OnSliderValueChanged(fadeSlider.value);
        }
    }

    void Update()
    {
        currentAlpha1 = Mathf.Lerp(currentAlpha1, targetAlpha1, Time.deltaTime / fadeDuration);
        currentAlpha2 = Mathf.Lerp(currentAlpha2, targetAlpha2, Time.deltaTime / fadeDuration);
        currentAlpha3 = Mathf.Lerp(currentAlpha3, targetAlpha3, Time.deltaTime / fadeDuration);

        SetImageAlpha(targetImage, currentAlpha1);
        SetImageAlpha(targetImage2, currentAlpha2);
        SetImageAlpha(targetImage3, currentAlpha3);
    }

    void OnSliderValueChanged(float value)
    {
        if (value < 3)
        {
            targetAlpha1 = 1f;
            targetAlpha2 = 0f;
            targetAlpha3 = 0f;
            currentOption = "sp";
        }
        else if (value >= 3 && value < 6)
        {
            targetAlpha1 = 1f;
            targetAlpha2 = 1f;
            targetAlpha3 = 0f;
            currentOption = "sx";
        }
        else
        {
            targetAlpha1 = 1f;
            targetAlpha2 = 1f;
            targetAlpha3 = 1f;
            currentOption = "so";
        }
    }

    void SetImageAlpha(Image image, float alpha)
    {
        if (image != null)
        {
            Color tempColor = image.color;
            tempColor.a = alpha;
            image.color = tempColor;
        }
    }

    // Public method to get the current option
    public string GetCurrentOption()
    {
        return currentOption;
    }
}