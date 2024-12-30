// using UnityEngine;
// using TMPro;

// public class SignBehavior : MonoBehaviour
// {
//     [SerializeField] private string guideMessage;        // Message to display
//     [SerializeField] private TextMeshProUGUI guideText;  // Reference to TextMeshProUGUI
//     // [SerializeField] private GameObject guideBackground; // Reference to the background GameObject (if needed)

//     private void OnTriggerEnter(Collider collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             // Show the guide panel with the message
//             guideText.text = guideMessage;
//             // guideBackground.SetActive(true); // Uncomment if you have a background GameObject
//             guideText.gameObject.SetActive(true);
//         }
//     }

//     private void OnTriggerExit(Collider collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             // Hide the guide panel when the player exits
//             // guideBackground.SetActive(false); // Uncomment if you have a background GameObject
//             guideText.gameObject.SetActive(false);
//         }
//     }
// }


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
