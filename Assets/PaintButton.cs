using UnityEngine;

public class PaintButton : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject itemToDeletePrefab;
    public GameObject itemPrefab;
    


    public void generatePlatform()
    {
        Debug.Log("Generating platform.");
        // Instantiate the platform prefab at the current position of the PaintButton
        GameObject newPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        // newPlatform.transform.localScale = new Vector3(1f, 1f, 1f); // Set the scale to 1x1x1
        newPlatform.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y - 0.5f, transform.position.z);
         // Adjust the position to be below the PaintButton

        GameObject newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        // newItem.transform.localScale = new Vector3(1f, 1f, 1f); // Set the scale to 1x1x1
        newItem.transform.position = new Vector3(transform.position.x + 2f, transform.position.y + 1.5f, transform.position.z);

        Destroy(itemToDeletePrefab);
    }
}
