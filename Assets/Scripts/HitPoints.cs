using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    public int maxHitPoints = 10;

    public int hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }

    /**
     * Reduces hitpoints by amount
     * Returns true if damage kills target
     */
    public bool damage(int amount)
    {
        hitPoints -= amount;
        return hitPoints <= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }
}
