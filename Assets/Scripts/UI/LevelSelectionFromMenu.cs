using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionFromMenu : MonoBehaviour
{
    public Transform levelSelection;

    public void ToLevelSelection()
    {
        levelSelection.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
