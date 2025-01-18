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
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material orangeMaterial;
    [SerializeField] private Material greenMaterial;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Blue()
    {
        PlayerPrefs.SetInt("Colour", 0);
        playerMaterial.color = blueMaterial.color;
        LoadGame();
    }
    public void Orange()
    {
        PlayerPrefs.SetInt("Colour", 0);
        playerMaterial.color = orangeMaterial.color;
        LoadGame();
    }

    public void Green()
    {
        PlayerPrefs.SetInt("Colour", 0);
        playerMaterial.color = greenMaterial.color;
        LoadGame();
    }

    public void LoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
