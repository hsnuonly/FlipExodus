using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowControl : MonoBehaviour {

    public void restart()
    {
        Application.LoadLevel("mainGame");
    }
    public void return2title()
    {
        Application.LoadLevel("menu");
    }
}
