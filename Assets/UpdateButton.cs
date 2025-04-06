using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateButton : MonoBehaviour
{
public void LoadNextScene()
{
  int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
if (SceneManager.sceneCount > nextSceneIndex)
{
    SceneManager.LoadScene(nextSceneIndex);
}
}
    }
    