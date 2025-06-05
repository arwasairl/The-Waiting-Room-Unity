using UnityEngine;
using TMPro;

public class KeypadDigits : MonoBehaviour
{
    public TextMeshPro textMesh; // Assign in Inspector

    void Start()
    {
        UpdateText();
        GlobalVar.Instance.OnArrayChanged += UpdateText;
    }

    void OnDestroy()
    {
        GlobalVar.Instance.OnArrayChanged -= UpdateText;
    }

    void UpdateText()
    {
        int[] array = GlobalVar.Instance.keyPadDigits;

        // Get the last 4 elements or fewer
        int count = Mathf.Min(array.Length, 4);
        int startIndex = array.Length - count;

        string result = "";
        for (int i = startIndex; i < array.Length; i++)
        {
            result += array[i].ToString();
        }

        // Pad with leading zeros to ensure 4 characters
        result = result.PadLeft(4, '0');

        // Trim if over 4 characters (just in case)
        if (result.Length > 4)
        {
            result = result.Substring(result.Length - 4);
        }

        textMesh.text = result;
    }
}