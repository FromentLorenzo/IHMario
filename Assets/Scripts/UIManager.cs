using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets
{
    public class UIManager : MonoBehaviour
    {
        // Public reference to the TextMeshProUGUI element that will display the lap information
        public TextMeshProUGUI lapText;

        // Public method to update the lap text
        public void UpdateLapText(string message)
        {
            // Set the text of the TextMeshProUGUI component
            lapText.text = message;
        }
    }
}