using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas canvasPause;
    [SerializeField] private Canvas canvasShop;

    private void Start()
    {
        Time.timeScale = 1f;
        canvas.enabled = true;
        canvasPause.enabled = false;
        canvasShop.enabled = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        canvas.enabled = false;
        canvasPause.enabled = true;
    }

    public void PlayPause()
    {
        Time.timeScale = 1f;
        canvasPause.enabled = false;
        canvas.enabled = true;
    }
    public void PlayShop()
    {
        Time.timeScale = 1f;
        canvasShop.enabled = false;
        canvas.enabled = true;
    }

    public void Shop()
    {
        canvasShop.enabled = true;
        canvasPause.enabled = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        canvas.enabled = true;
        canvasPause.enabled = false;
        canvasPause.enabled = false;
    }
}
