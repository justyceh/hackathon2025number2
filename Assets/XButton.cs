using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject windowToClose;
    public Transform workspaceAnchor;
    public GameObject UpdateWindow;
    static bool spawnAdsNow = false;
    public bool isAppWindowOpen = true;
    public bool isUpdateWindowOpen = false;

    public void closeApp(){
        if (!isAppWindowOpen) return;
        isAppWindowOpen = false;
        Destroy(windowToClose);
        Debug.Log("App Closed!");
        if (isUpdateWindowOpen) return; // Prevent launching if already open or not closed
        isUpdateWindowOpen = true;
        spawnAdsNow = true; // Set the flag to true to spawn the update window
        Vector3 spawnPosition = workspaceAnchor ? workspaceAnchor.position : new Vector3(0, 1, 0); // Example position
        Instantiate(UpdateWindow, spawnPosition, Quaternion.identity);
        Debug.Log("Window update launched!");
    }
    
 
}