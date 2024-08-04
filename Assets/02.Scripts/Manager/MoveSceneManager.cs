using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
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
}
