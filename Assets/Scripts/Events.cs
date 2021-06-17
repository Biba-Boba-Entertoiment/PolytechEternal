using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    //replay level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.score = 0;
    }

    //quit game
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        GameController.score = 0;
    }
}
