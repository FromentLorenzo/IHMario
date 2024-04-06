using Assets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps = 3;
    public UIManager ui;

    private Dictionary<CarIdentity, int> carLaps = new Dictionary<CarIdentity, int>();
    public UnityEvent onPlayerFinished = new UnityEvent();
    public UnityEvent onPlayerLose = new UnityEvent();

    void Start()
    {
        // Get players in the scene
        foreach (CarIdentity carIdentity in GameObject.FindObjectsOfType<CarIdentity>())
        {
            carLaps.Add(carIdentity, 0); // Start with 0 laps
        }
        ListenCheckpoints(true);
        CarIdentity mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CarIdentity>();
        if (mainPlayer != null && carLaps.ContainsKey(mainPlayer))
        {
            ui.UpdateLapText("Lap " + (carLaps[mainPlayer]) + " / " + (totalLaps-1));
        }
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if(subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(GameObject carGameObject, Checkpoint checkpoint)
    {
        CarIdentity car = carGameObject.GetComponent<CarIdentity>();
        if (car == null) return;
        if (checkpoints.Contains(checkpoint) && carLaps.ContainsKey(car))
        {
            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            bool startingFirstLap = checkpointNumber == 0 && (carLaps[car] == 0);
            bool lapIsFinished = checkpointNumber == 0 && carLaps[car] < totalLaps;

            if (startingFirstLap || lapIsFinished)
            {
                carLaps[car]++;

                if (carLaps[car] >= totalLaps)
                {
                    // The car has finished the race
                    if (car.gameObject.tag == "Player")
                    {
                        ui.UpdateLapText("You finished the race!");
                        onPlayerFinished.Invoke();
                    }
                    else {
                        ui.UpdateLapText(car.name + " finished the race!");
                        onPlayerLose.Invoke();
                    }
                }
                else
                {
                    // Update lap text for the player
                    if (car.gameObject.tag == "Player")
                    {
                        ui.UpdateLapText((carLaps[car]) + " / " + (totalLaps-1));
                    }
                }

            }
        }
    }
}
