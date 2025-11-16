using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderScript : MonoBehaviour
{
    public Slider fadeSlider;
    public Image targetImage;
    public Image targetImage2;
    public Image targetImage3;

    [Header("Fade Settings")]
    public float fadeDuration = 0.3f; // How long the fade takes

    [Header("Scene Settings")]
    public int nextSceneIndex = 3; // Scene to load when clicking
    public int pointsToAdd = 2; // How many points to add

    private float currentAlpha1 = 1f;
    private float currentAlpha2 = 0f;
    private float currentAlpha3 = 0f;

    private float targetAlpha1 = 1f;
    private float targetAlpha2 = 0f;
    private float targetAlpha3 = 0f;

    private string currentOption = "so"; // Tracks which option is currently selected
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        
        if (gameManager == null)
        {
            Debug.LogError("SliderScript: GameManager instance not found!");
        }

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
        // Show only image 1 (SO) when slider is 0-2
        if (value < 3)
        {
            targetAlpha1 = 1f;
            targetAlpha2 = 0f;
            targetAlpha3 = 0f;
            currentOption = "so";
        }
        // Show only image 2 (SP) when slider is 3-5
        else if (value >= 3 && value < 6)
        {
            targetAlpha1 = 0f;
            targetAlpha2 = 1f;
            targetAlpha3 = 0f;
            currentOption = "sp";
        }
        // Show only image 3 (SX) when slider is 6+
        else
        {
            targetAlpha1 = 0f;
            targetAlpha2 = 0f;
            targetAlpha3 = 1f;
            currentOption = "sx";
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

    // Call this method when the player clicks to continue
    public void OnContinueClicked()
    {
        if (gameManager != null)
        {
            gameManager.AddPoints(currentOption, pointsToAdd);
            Debug.Log($"Added {pointsToAdd} points to {currentOption}");
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("GameManager is not available!");
        }
    }

    // If you want to use OnMouseDown on this GameObject
    void OnMouseDown()
    {
        OnContinueClicked();
    }
}