using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    private Button button;
    private Color originalColor;

    void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.GetComponent<Image>().color;
    }

    public void OnHoverEnter()
    {
        button.GetComponent<Image>().color = Color.gray;  // Change color on hover
    }

    public void OnHoverExit()
    {
        button.GetComponent<Image>().color = originalColor;  // Restore original color
    }
}