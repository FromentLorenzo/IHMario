using System.Collections; using UnityEngine;
public class GameManager : MonoBehaviour
{
   public PlayerControls playerControls;
   public AIControls[] aiControls;
   public LapManager lapTracker;
   public TricolorLights tricolorLights;

   public AudioSource audioSource;
   public AudioClip lowBeep;
   public AudioClip highBeep;

   void Awake()
   {
       StartGame();
   }
   public void StartGame()
   {
       FreezePlayers(true);
       StartCoroutine("Countdown");
   }
   IEnumerator Countdown()
   {
       yield return new WaitForSeconds(1);
       tricolorLights.SetProgress(1);
       audioSource.PlayOneShot(lowBeep);
       yield return new WaitForSeconds(1);
       tricolorLights.SetProgress(2);
       audioSource.PlayOneShot(lowBeep);
       yield return new WaitForSeconds(1);
       tricolorLights.SetProgress(3);
       audioSource.PlayOneShot(lowBeep);
       yield return new WaitForSeconds(1);
       tricolorLights.SetProgress(4);
       StartRacing();
       audioSource.PlayOneShot(highBeep);
       yield return new WaitForSeconds(2f);
       tricolorLights.SetAllLightsOff();
   }
   public void StartRacing()
   {
       FreezePlayers(false);
   }
   void FreezePlayers(bool freeze)
{
    playerControls.enabled = !freeze;
    foreach (var aiControl in aiControls)
    {
        aiControl.enabled = !freeze;
    }
}
}