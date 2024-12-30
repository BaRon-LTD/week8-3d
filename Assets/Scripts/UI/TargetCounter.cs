using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText; // Reference to the TextMeshPro UI component
    [SerializeField] private Transform targetsFolder; // The folder containing all target GameObjects
    private int totalTargets;
    private int destroyedTargets;

    void Start()
    {
        if (targetsFolder == null)
        {
            Debug.LogError("Targets folder is not assigned!");
            return;
        }

        // Initialize target counts
        totalTargets = targetsFolder.childCount;
        destroyedTargets = 0;

        // Assign this TargetCounter to all targets
        foreach (Transform target in targetsFolder)
        {
            Target targetScript = target.GetComponent<Target>();
            if (targetScript != null)
            {
                targetScript.Initialize(this); // Pass a reference of this TargetCounter
            }
        }

        // Update the UI text at the start
        UpdateTargetText();
    }

    public void TargetDestroyed()
    {
        destroyedTargets++;
        UpdateTargetText();
    }

    private void UpdateTargetText()
    {
        if (targetText != null)
        {
            targetText.text = $"Targets Destroyed: {destroyedTargets} / {totalTargets}";
        }
        else
        {
            Debug.LogWarning("Target text UI is not assigned!");
        }
    }
}
