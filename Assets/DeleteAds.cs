using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class deleteAds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tempInteraction.deleted == true)
        {
            deleteSelf();
        }
    }

    void deleteSelf()
    {
        Destroy(this.gameObject);
    }

}
