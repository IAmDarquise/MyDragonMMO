using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private int redInput;
    [SerializeField] private int greenInput;
    [SerializeField] private int blueInput;
    [SerializeField] private Image colourPreview;
    [SerializeField]private Color newColour;



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

    void LoadGame()
    {
        SceneManager.LoadScene("Client");
    }

    public void SetName(string name)
    {
        PlayerPrefs.SetString("Name", name);
    }

    public void SetR(string value)
    {
        int.TryParse(value, out int r);
        redInput = r;
        PreviewColour();
    }

    public void SetG(string value)
    {
        int.TryParse(value, out int g);
        greenInput = g;
        PreviewColour();
    }

    public void SetB(string value)
    {
        int.TryParse(value, out int b);
        blueInput = b;
        PreviewColour();
    }

    public void PreviewColour()
    {
        newColour = new Color(redInput, greenInput, blueInput);

        colourPreview.color = newColour;
    }

}
