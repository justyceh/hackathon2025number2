using UnityEngine;

public class IconLauncher : MonoBehaviour
{
    public GameObject appWindowPrefab;
    public Transform workspaceAnchor;

    public bool isAppWindowOpen = false;
    public bool isAppWindowClosed = true;

    public void LaunchApp()
    {
        if (isAppWindowOpen || !isAppWindowClosed) return; // Prevent launching if already open or not closed
        isAppWindowOpen = true;
        Vector3 spawnPosition = workspaceAnchor ? workspaceAnchor.position : new Vector3(0, 1, 0); // Example position
        Instantiate(appWindowPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("App launched!");
    }
}
