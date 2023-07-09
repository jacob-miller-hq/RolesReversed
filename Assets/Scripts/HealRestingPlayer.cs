using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRestingPlayer : MonoBehaviour
{
    public float healSpeed = 0.1f;
    List<GameObject> players = new List<GameObject>();

    float lastHeal = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastHeal > 1f)
        {
            players.ForEach(player =>
            {
                if (player.GetComponent<Rigidbody2D>().velocity.magnitude < 1)
                {
                    player.GetComponent<HitPoints>().heal((int)(healSpeed * gameObject.GetComponentInChildren<PileOfGold>().amount));
                    lastHeal = Time.time;
                }
            });
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            players.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        players.Remove(collision.gameObject);
    }
}
