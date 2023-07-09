using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlainOnDestroy : MonoBehaviour
{
    public List<GameObject> drops;
    public bool shouldDrop = true;

    private void OnApplicationQuit()
    {
        shouldDrop = false;
    }

    private void OnDestroy()
    {
        Debug.Log("1");
        if (shouldDrop)
        {
            Debug.Log("2");
            SceneManager.LoadScene("Slain");
        }
    }
}