using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    public int maxHitPoints = 10;
    public GameObject hpBar;

    int hitPoints;

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
        hitPoints = Mathf.Max(hitPoints, 0);
        return hitPoints <= 0;
    }

    public void heal(int amount)
    {
        // Debug.Log("Healing: " + amount + " hit points -- " + hitPoints + "/" + maxHitPoints);
        hitPoints = Mathf.Min(hitPoints + amount, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (hpBar != null)
        {
            hpBar.transform.localScale = new Vector2((float) hitPoints / maxHitPoints, 1);
        }
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }
}
