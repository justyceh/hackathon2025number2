using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEditor;

public class spawn_ads : MonoBehaviour
{

    [SerializeField] private GameObject ad;
    public List<GameObject> instantiatedAds = new List<GameObject>();
    public int numAds = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ExitButton.spawnAdsNow)
        {
            StartCoroutine(waitSauce());
            if (numAds < 6)
            {
                StartCoroutine(spawnAds());
            }
        }
    }

    private void FixedUpdate()
    {

    }

    private IEnumerator<WaitForSeconds> spawnAds()
    {
        float randx = Random.Range(-7, 7);
        float randy = Random.Range(-3.7f, 3.7f);

        Debug.Log(numAds);
        GameObject newAd = Instantiate(ad, new Vector3(randx, randy, 0), Quaternion.identity);
        numAds++;
        instantiatedAds.Add(newAd);

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator<WaitForSeconds> waitSauce()
    {
        yield return new WaitForSeconds(3f);
    }
}
