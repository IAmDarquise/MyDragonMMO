using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
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
}
