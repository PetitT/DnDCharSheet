using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontWhatever : MonoBehaviour
{
    public TMP_FontAsset font;

    [ContextMenu("Modify Font")]
    public void ModifyFont()
    {
        foreach (var tmp in FindObjectsOfType<TextMeshProUGUI>())
        {
            tmp.alignment = TextAlignmentOptions.Center;

        }

        foreach (var tmp in FindObjectsOfType<TMP_InputField>())
        {
            tmp.pointSize = 18;
        }
    }
}
