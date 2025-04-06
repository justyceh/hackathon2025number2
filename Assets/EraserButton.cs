using UnityEngine;

public class EraserButton : MonoBehaviour
{
    public GameObject itemToErase;
    public GameObject eraserPrefab; // Reference to the eraser prefab

    public void Erase()
    {
        Debug.Log("Erasing item");
        Destroy(itemToErase);
        Destroy(eraserPrefab); // Destroy the eraser prefab after use
    }
}
