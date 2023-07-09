using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    public List<GameObject> drops;
    public bool shouldDrop = true;

    private void OnApplicationQuit()
    {
        shouldDrop = false;
    }

    private void OnDestroy()
    {
        if (shouldDrop)
        {
            drops.ForEach(drop =>
            {
                GameObject dropInstance = Instantiate(drop);
                dropInstance.transform.position = transform.position;
            });
        }
    }
}
