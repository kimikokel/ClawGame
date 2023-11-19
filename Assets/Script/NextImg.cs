using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextImg : MonoBehaviour
{
    public GameObject[] imgs;
    private int currentIndex = 0;

    void Start()
    {
        // Activate the first object in the list at the start
        if (imgs.Length > 0)
        {
            ActivateObject(currentIndex);
        }
    }

    public void OnButtonClick()
    {
        // Deactivate the current object
        DeactivateObject(currentIndex);

        // Move to the next object (looping back to the beginning if necessary)
        currentIndex = (currentIndex + 1) % imgs.Length;

        // Activate the next object
        ActivateObject(currentIndex);
    }

    void ActivateObject(int index)
    {
        imgs[index].SetActive(true);
    }

    void DeactivateObject(int index)
    {
        imgs[index].SetActive(false);
    }
}
