using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEditor;

public class spawn_ads : MonoBehaviour
{
    private SpriteRenderer adSpriteRenderer;
    private GameObject bg;
    private List<Sprite> adSprites = new List<Sprite>();

    [SerializeField] private Sprite ad1Sprite;
    [SerializeField] private Sprite ad2Sprite;
    [SerializeField] private Sprite ad3Sprite;
    [SerializeField] private Sprite ad4Sprite;
    [SerializeField] private Sprite ad5Sprite;
    [SerializeField] private Sprite ad6Sprite;

    [SerializeField] private GameObject ad;
    public List<GameObject> instantiatedAds = new List<GameObject>();
    public int numAds = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        adSprites.Add(ad1Sprite);
        adSprites.Add(ad2Sprite);
        adSprites.Add(ad3Sprite);
        adSprites.Add(ad4Sprite);
        adSprites.Add(ad5Sprite);
        adSprites.Add(ad6Sprite);
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

        bg = ad.transform.GetChild(0).gameObject;
        adSpriteRenderer = bg.GetComponent<SpriteRenderer>();
        //adSpriteRenderer.bounds.size() = new Vector3(1, 1, 1);
        adSpriteRenderer.sprite = adSprites[numAds];
        Debug.Log(numAds);
        GameObject newAd = Instantiate(ad, new Vector3(randx, randy, 0), Quaternion.identity);
        numAds++;
        instantiatedAds.Add(newAd);

        yield return new WaitForSeconds(5f);
    }

    private IEnumerator<WaitForSeconds> waitSauce()
    {
        yield return new WaitForSeconds(20f);
    }
}
