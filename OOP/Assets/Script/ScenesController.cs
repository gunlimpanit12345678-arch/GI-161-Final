using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void ScenesChange(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }
}
