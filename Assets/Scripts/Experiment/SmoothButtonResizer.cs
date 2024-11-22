using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SmoothButtonResizer : MonoBehaviour
{
    public Image[] buttons; // Reference to your buttons
    public float expandedSize = 170f; // New size when button is hovered
    public float defaultSize = 150f; // Default size
    public float resizeDuration = 0.3f; // Duration of the resize animation

    private void Start()
    {
        // Attach the pointer enter event handler to each button
        foreach (var button in buttons)
        {
            // Add pointer enter event trigger
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            // Create a new event entry
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };

            // Add listener to the entry
            entry.callback.AddListener((eventData) => OnButtonHover(button));

            // Add the entry to the trigger
            trigger.triggers.Add(entry);
        }
    }

    private void OnButtonHover(Image hoveredButton)
    {
        // Reset all buttons to default size
        foreach (var button in buttons)
        {
            ResizeButton(button, defaultSize);
        }

        // Expand the hovered button
        ResizeButton(hoveredButton, expandedSize);
    }

    private void ResizeButton(Image button, float targetSize)
    {
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        Vector2 currentSize = rectTransform.sizeDelta;

        // Calculate the size difference
        Vector2 sizeDifference = new Vector2(targetSize - currentSize.x, targetSize - currentSize.y);

        // Start a coroutine to gradually resize the button
        StartCoroutine(ResizeOverTime(rectTransform, currentSize, sizeDifference, resizeDuration));
    }

    private IEnumerator ResizeOverTime(RectTransform rectTransform, Vector2 startSize, Vector2 sizeDifference, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the new size based on elapsed time
            Vector2 newSize = startSize + sizeDifference * (elapsedTime / duration);

            // Apply the new size to the button
            rectTransform.sizeDelta = newSize;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final size is exact
        rectTransform.sizeDelta = startSize + sizeDifference;
    }
}
