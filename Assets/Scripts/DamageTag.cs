using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.UIElements;
using UnityEngine;

public class DamageTag : MonoBehaviour
{
    // will do damage to 
    public string targetTag;
    public int damageAmt = 10;
    public float timePerHit = 0.5f;

    List<GameObject> targets;
    float lastHitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0 && Time.time - lastHitTime >= timePerHit)
        {
            hit();
        }
    }

    void hit()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<HitPoints>().damage(damageAmt);
        }
        lastHitTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetTag == other.gameObject.tag)
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targets.Remove(other.gameObject);
    }
}
