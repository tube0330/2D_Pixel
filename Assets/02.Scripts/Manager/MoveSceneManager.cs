using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("PlayScene"); // 로드할 씬 이름
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif              //전처리기 지시어 끝
    }
}
