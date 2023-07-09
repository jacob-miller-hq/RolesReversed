using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject path;
    public GameObject hoard;
    public GameObject pileOfGoldPrefab;
    public float speed = 0.1f;
    public EnemyState state;

    public enum EnemyState {
        approaching,
        stealing,
        escaping,
    };

    FollowPath followPath;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.approaching;
        followPath = gameObject.AddComponent<FollowPath>();
        followPath.path = path;
        followPath.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.approaching:
                if (followPath.done)
                {
                    Destroy(followPath);
                    state = EnemyState.stealing;
                }
                break;
            case EnemyState.stealing:
                steal();
                break;
            case EnemyState.escaping:
            default:
                if (followPath.done)
                {
                    gameObject.GetComponent<DropOnDestroy>().shouldDrop = false;
                    Destroy(gameObject);
                }
                break;
        }
    }

    void steal()
    {
        // steal gold
        int amtStolen = Mathf.Min(hoard.GetComponentInChildren<PileOfGold>().amount, 100);
        if (amtStolen > 0)
        {
            hoard.GetComponentInChildren<PileOfGold>().amount -= amtStolen;
            GameObject loot = pileOfGoldPrefab;
            loot.GetComponent<PileOfGold>().amount = amtStolen;
            GetComponent<DropOnDestroy>().drops.Add(loot);
        }

        // begin escape
        state = EnemyState.escaping;
        followPath = gameObject.AddComponent<FollowPath>();
        followPath.path = path;
        followPath.speed = speed;
        followPath.reverse = true;
    }
}
