using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject[] ImageAppear; 
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject image in ImageAppear) image.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject image in ImageAppear) image.SetActive(true);
    }
}

