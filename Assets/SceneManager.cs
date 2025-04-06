using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Set this in the inspector

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
