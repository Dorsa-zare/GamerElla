using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider fadeSlider;
    public Image targetImage;
    public Image targetImage2;
    public Image targetImage3;

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

    void OnSliderValueChanged(float value)
    {
        // Show only image 1 when slider is 0-2
        if (value < 3)
        {
            SetImageAlpha(targetImage, 1f);
            SetImageAlpha(targetImage2, 0f);
            SetImageAlpha(targetImage3, 0f);
        }
        // Show only image 2 when slider is 3-5
        else if (value >= 3 && value < 6)
        {
            SetImageAlpha(targetImage, 0f);
            SetImageAlpha(targetImage2, 1f);
            SetImageAlpha(targetImage3, 0f);
        }
        // Show only image 3 when slider is 6+
        else
        {
            SetImageAlpha(targetImage, 0f);
            SetImageAlpha(targetImage2, 0f);
            SetImageAlpha(targetImage3, 1f);
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
