using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGold : MonoBehaviour
{
    public int maxCarry = 200;

    int carryAmt = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            carryAmt += collision.gameObject.GetComponent<PileOfGold>().amount;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Hoard")
        {
            collision.gameObject.GetComponentInChildren<PileOfGold>().amount += carryAmt;
            carryAmt = 0;
        }
    }
}
