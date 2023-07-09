using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfGold : MonoBehaviour
{
    public int amount = 20;

    private void Update()
    {
        float scale = Mathf.Sqrt(amount) / 10;
        gameObject.transform.localScale = new Vector2(scale, scale);
    }
}
