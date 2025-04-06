using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateButton : MonoBehaviour
{
    public void LoadNextScene()
    {
  
int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene("2ndScene");
        }
        if (currentSceneIndex == 2)
        {
            SceneManager.LoadScene("3rdScene");
        }
        
    }
}
    