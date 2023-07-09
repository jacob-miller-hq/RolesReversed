using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Slain : MonoBehaviour
{
    public void onPointerClickEventTrigger()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
