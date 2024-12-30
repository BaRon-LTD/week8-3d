using UnityEngine;
using TMPro;

public class SignBehavior : MonoBehaviour
{
    [SerializeField] private string guideMessage;       // Message to display
    [SerializeField] private TextMeshProUGUI guideText; // Reference to TextMeshProUGUI
    [SerializeField] private GameObject guidePanel;     // Reference to the panel GameObject

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Show the panel with the message
            guideText.text = guideMessage;
            guidePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Hide the panel when the player exits
            guidePanel.SetActive(false);
        }
    }
}
