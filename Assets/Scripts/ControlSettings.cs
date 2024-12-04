using UnityEngine;
using TMPro; // Import cho TextMeshPro

public class ControlInstruction : MonoBehaviour
{
    public TMP_Text controlInstructionText;
    public TMP_Text controlInstructionText1;

    private void Start()
    {
        // Chỉ để lại gán biến và không cần thay đổi text trong mã.
        if (controlInstructionText == null)
        {
            Debug.LogError("ControlInstructionText chưa được gán trong Inspector!");
        }
        else if (controlInstructionText1 == null)
            {
                Debug.LogError("ControlInstructionText chưa được gán trong Inspector!");
            }
    }
}
