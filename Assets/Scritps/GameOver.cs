using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        //open confirm panel
        Application.Quit();
    }
}
