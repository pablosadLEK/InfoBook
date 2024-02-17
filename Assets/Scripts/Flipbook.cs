using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flipbook : MonoBehaviour
{
    public Button backButton;
    public Button nextButton;

    private Animator anim;
    public int currentPage = 1; // Assuming 1-based indexing for pages
    public int totalPages = 3;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        // Assign methods to button click events
        backButton.onClick.AddListener(FlipToPreviousPage);
        nextButton.onClick.AddListener(FlipToNextPage);

        // Set the initial button visibility
        UpdateButtonVisibility();

        totalPages = 3;
    }

    void FlipToPreviousPage()
    {
        if (currentPage > 1)
        {
            currentPage--;
            anim.SetTrigger("BackPage01"); // Use the trigger name you set in Animator
            UpdateButtonVisibility();
        }
    }

    void FlipToNextPage()
    {
        // Add logic to check if there's a next page
        // For example, check against the total number of pages
        int totalPages = 2; // Change this to your total number of pages

        if (currentPage < totalPages)
        {
            currentPage++;
            anim.SetTrigger("NextPage23"); // Use the trigger name you set in Animator
            UpdateButtonVisibility();
        }
    }

    void UpdateButtonVisibility()
    {
        // Disable the back button if on the first page
        backButton.gameObject.SetActive(currentPage > 1);

        // Disable the next button if on the last page
        nextButton.gameObject.SetActive(currentPage < totalPages);
    }
}