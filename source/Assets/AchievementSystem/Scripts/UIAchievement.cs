using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Defines the logic behind a single achievement on the UI
/// </summary>
public class UIAchievement : MonoBehaviour
{
    public TMP_Text Title, Description;
    public Image Icon, OverlayIcon;
    public GameObject SpoilerOverlay;
    public TMP_Text SpoilerText;
    [HideInInspector]public AchievenmentStack AS;

    /// <summary>
    /// Destroy object after a certain amount of time
    /// </summary>
    public void StartDeathTimer ()
    {
        StartCoroutine(Wait());
    }

    /// <summary>
    /// Add information  about an Achievement to the UI elements
    /// </summary>
    public void Set (AchievementInfromation Information, AchievementState State)
    {
        if(Information.Spoiler && !State.Achieved)
        {
            SpoilerOverlay.SetActive(true);
            SpoilerText.text = AchievementManager.instance.SpoilerAchievementMessage;
        }
        else
        {
            Title.text = Information.DisplayName;
            Description.text = Information.Description;

            if (Information.LockOverlay && !State.Achieved)
            {
                OverlayIcon.gameObject.SetActive(true);
                OverlayIcon.sprite = Information.LockedIcon;
                Icon.sprite = Information.AchievedIcon;
            }
            else
            {
                Icon.sprite = State.Achieved ? Information.AchievedIcon : Information.LockedIcon;
            }
        }
    }

    private IEnumerator Wait ()
    {
        yield return new WaitForSeconds(AchievementManager.instance.DisplayTime);
        GetComponent<Animator>().SetTrigger("ScaleDown");
        yield return new WaitForSeconds(0.1f);
        AS.CheckBackLog();
        Destroy(gameObject);
    }
}
