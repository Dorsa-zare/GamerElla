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
    public float fadeDuration = 0.3f; // How long the fade takes

    private float currentAlpha1 = 1f;
    private float currentAlpha2 = 0f;
    private float currentAlpha3 = 0f;

    private float targetAlpha1 = 1f;
    private float targetAlpha2 = 0f;
    private float targetAlpha3 = 0f;

    void Start()
    {
        // Add a listener to the slider's OnValueChanged event
        if (fadeSlider != null)
        {
            fadeSlider.onValueChanged.AddListener(OnSliderValueChanged);
            // Initialize the images based on the slider's initial value
            OnSliderValueChanged(fadeSlider.value);
        }
    }

    void Update()
    {
        // Smoothly interpolate current alphas toward target alphas
        currentAlpha1 = Mathf.Lerp(currentAlpha1, targetAlpha1, Time.deltaTime / fadeDuration);
        currentAlpha2 = Mathf.Lerp(currentAlpha2, targetAlpha2, Time.deltaTime / fadeDuration);
        currentAlpha3 = Mathf.Lerp(currentAlpha3, targetAlpha3, Time.deltaTime / fadeDuration);

        // Apply the interpolated alphas to the images
        SetImageAlpha(targetImage, currentAlpha1);
        SetImageAlpha(targetImage2, currentAlpha2);
        SetImageAlpha(targetImage3, currentAlpha3);
    }

    void OnSliderValueChanged(float value)
    {
        // Set target alphas based on slider value
        // Show only image 1 when slider is 0-2
        if (value < 3)
        {
            targetAlpha1 = 1f;
            targetAlpha2 = 0f;
            targetAlpha3 = 0f;
        }
        // Show only image 2 when slider is 3-5
        else if (value >= 3 && value < 6)
        {
            targetAlpha1 = 0f;
            targetAlpha2 = 1f;
            targetAlpha3 = 0f;
        }
        // Show only image 3 when slider is 6+
        else
        {
            targetAlpha1 = 0f;
            targetAlpha2 = 0f;
            targetAlpha3 = 1f;
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
}
