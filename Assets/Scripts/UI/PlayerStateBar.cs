using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateBar : MonoBehaviour
{
    public Image healthImage;
    public Image healthImageDelay;
    public Image powerImage;
    public float fillDelta = 0.15f;
    private void Update() {
        if (healthImageDelay.fillAmount > healthImage.fillAmount)
        {
            healthImageDelay.fillAmount -= Time.deltaTime * 0.2f;
        }
    }
    /// <summary>
    /// 血条
    /// </summary>
    /// <param name="persentage"></param>
    public void OnHealthChange(float persentage){
        healthImage.fillAmount = persentage;
    }
}
