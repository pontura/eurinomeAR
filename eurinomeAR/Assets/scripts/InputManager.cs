using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            int i = 0;
            while (i < hits.Length)
            {
                RaycastHit hit = hits[i];
                Debug.Log(hit.collider.gameObject.name);
                ARButton button = hit.transform.gameObject.GetComponent<ARButton>();
                if (button != null)
                    button.OnButtonClick();
                i++;
            }
        }
    }
}
