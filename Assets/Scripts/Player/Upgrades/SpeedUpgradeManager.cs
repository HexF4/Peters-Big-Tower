using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgradeManager : MonoBehaviour
{
    public Text speedUpgradeText;
    public FirstPersonController player;
    public float baseSpeed = 5f;
    public float speedMultiplier = 1.2f;

    private int lastUpgradeCount = -1;

    void Update()
    {
        if (int.TryParse(speedUpgradeText.text, out int upgradeCount))
        {
            if (upgradeCount != lastUpgradeCount)
            {
                float newSpeed = baseSpeed * Mathf.Pow(speedMultiplier, upgradeCount);
                player.SprintSpeed = newSpeed;
                lastUpgradeCount = upgradeCount;
                Debug.Log("Updated speed: " + newSpeed);
            }
        }
    }
}
