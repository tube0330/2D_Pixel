using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneManager : MonoBehaviour
{
    public static MoveSceneManager S_instance;
    void Awake()
    {
        if (S_instance == null)
            S_instance = this;

        else if (S_instance != this)
            Destroy(gameObject);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /* public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    } */
}
