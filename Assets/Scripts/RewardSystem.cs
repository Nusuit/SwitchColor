using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : BaseManager
{
    public Button claimButton;           // Button để nhận phần thưởng

    void Start()
    {
        claimButton.onClick.AddListener(ClaimReward);
    }

    // Hiển thị Reward panel và cập nhật phần thưởng
    public override void ShowPanel(int rewardPoints)
    {
        currentScore = rewardPoints;
        PlayerPrefs.SetInt("RewardPoints", currentScore);
        PlayerPrefs.Save();

        base.ShowPanel(currentScore);  // Gọi phương thức của lớp cha để hiển thị panel
    }

    // Nhận phần thưởng
    private void ClaimReward()
    {
        Debug.Log("Reward Claimed: " + currentScore + " points");
        ClosePanel();  // Đóng panel sau khi nhận phần thưởng
    }
}
