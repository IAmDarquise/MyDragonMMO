using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private int redInput;
    [SerializeField] private int greenInput;
    [SerializeField] private int blueInput;
    [SerializeField] private Image colourPreview;
    [SerializeField] private Color newColour;
    [SerializeField] private Material playerMaterial;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Blue()
    {
        PlayerPrefs.SetInt("Colour", 1);
        LoadGame();
    }
    public void Orange()
    {
        PlayerPrefs.SetInt("Colour", 2);
        LoadGame();
    }

    public void Green()
    {
        PlayerPrefs.SetInt("Colour", 3);
        LoadGame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Client");
    }

    public void SetName(string name)
    {
        PlayerPrefs.SetString("Name", name);
    }

    public void OnColorChange(Color color)
    {
        colourPreview.color = color;
        playerMaterial.color = color;
    }

    public void UseCustomColour()
    {
        PlayerPrefs.SetInt("Colour", 0);
        LoadGame();
    }

    public void LoadServer()
    {
        SceneManager.LoadScene("Server");
    }



}
