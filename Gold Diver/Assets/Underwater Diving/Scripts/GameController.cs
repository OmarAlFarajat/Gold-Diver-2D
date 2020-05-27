using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void GoToNormal()
    {
        SceneManager.LoadScene("Version-Normal");
    }
    public void GoToVariant()
    {
        SceneManager.LoadScene("Variant-Special");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }




}