using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverCanvasScript : MonoBehaviour
{
    public Canvas GameoverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        GameoverCanvas.enabled = false;
    }

    // Update is called once per frame
    public void GameOver()
    {
        GameoverCanvas.enabled = true;
    }
}
