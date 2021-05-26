using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame(string A)
    {
        SceneManager.LoadScene(A);
    }
    public void Restart(string B)
    {
        SceneManager.LoadScene(B);
    }
    public void GoBackToMainMenu(string C)
    {
        SceneManager.LoadScene(C);
    }
    public void ExitGame()
    {
        Debug.Log("Exitting");
        Application.Quit();
    }
}
