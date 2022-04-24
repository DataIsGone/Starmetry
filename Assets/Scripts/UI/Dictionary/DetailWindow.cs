using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailWindow : MonoBehaviour
{
    // ON CLICK

        // turn off panel options object
        // turn on detail window
        // fill detail window

        // create back button:
            // turn on panel options object
            // turn off detail window

    public void ActivateWindow() {
        ShowDetailWindow();
        FillWindow();
    }
    
    private void ShowDetailWindow() {
        gameObject.SetActive(true);
    }

    private void FillWindow() {

    }

}
