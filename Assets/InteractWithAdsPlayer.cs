using UnityEngine;
using System;
using System.Collections.Generic;

//private IEnumerator<WaitForSeconds> DisableCollision()
//{
//    BoxCollider2D platformCollider = holdBar.GetComponent<BoxCollider2D>();
//
//    Physics2D.IgnoreCollision(playerCollider, platformCollider);
//    yield return new WaitForSeconds(1f);
//    Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
//}

public class tempInteraction : MonoBehaviour
{
    private GameObject holdBar;
    private float initialPlayerDistx;
    private float initialHoldBarDistx;

    private deleteAds adblocker;
    private spawn_ads adListsauce;
    static public bool deleted = false;

    private float distx;


    private bool alreadyHolding;

    [SerializeField] private BoxCollider2D playerCollider;
    private Rigidbody2D player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyHolding)
        {
            if (collision.gameObject.CompareTag("holdBar"))
            {
                holdBar = collision.gameObject;
                initialPlayerDistx = player.transform.position.x;
                initialHoldBarDistx = holdBar.transform.position.x;
                distx = initialHoldBarDistx - initialPlayerDistx;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("i'm in the adblocker");
        if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("holdBar"))
        {
            alreadyHolding = true;
            holdBar.transform.position = new Vector3(distx + player.transform.position.x, player.transform.position.y, 0);
        }

        if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("adblocker"))
        {
            deleted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alreadyHolding = false;
    }
}


