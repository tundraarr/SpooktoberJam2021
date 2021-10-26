using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractTooltip : MonoBehaviour
{
    [SerializeField] private string interactMessage;

    public void ShowInteractText()
    {
        GetComponent<TextMeshProUGUI>().SetText(interactMessage);
    }

    public void HideInteractText()
    {
        GetComponent<TextMeshProUGUI>().SetText("");
    }
}
