using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public GameObject windowToClose;
    public Transform workspaceAnchor;
    public GameObject UpdateWindow;

    static public bool spawnAdsNow = false;
    public bool isAppWindowOpen = true;
    public bool isUpdateWindowOpen = false;

    public void closeApp(){
        if (!isAppWindowOpen) return;
        isAppWindowOpen = false;
        Destroy(windowToClose);
        Debug.Log("App Closed!");
        if (SceneManager.GetActiveScene().buildIndex == 0){
        Vector3 spawnPosition = workspaceAnchor ? workspaceAnchor.position : new Vector3(0, 1, 0); // Example position
        Instantiate(UpdateWindow, spawnPosition, Quaternion.identity);
        Debug.Log("Window update launched!");
        }
        if (SceneManager.GetActiveScene().buildIndex == 1){
        if (isUpdateWindowOpen) return; // Prevent launching if already open or not closed
        isUpdateWindowOpen = true;
        spawnAdsNow = true; // Set the flag to true to spawn the update window
        GameObject platform2 = GameObject.Find("PaintPlatform2(Clone)");
        GameObject platform3 = GameObject.Find("PaintPlatform3(Clone)");
        GameObject platform4 = GameObject.Find("PaintPlatform4(Clone)");
        Destroy(platform2);
        Destroy(platform3);
        Destroy(platform4);
        }
    }
    
 
}