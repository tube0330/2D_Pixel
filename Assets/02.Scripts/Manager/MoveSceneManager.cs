using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{

    public void LoadNextScene()
    {
        SceneManager.LoadScene("PlayScene"); // 로드할 씬 이름
    }
}
