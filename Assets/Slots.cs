using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slots : MonoBehaviour
{
    public Reel[] reels;
    public InputActionReference spin;
    bool startSpin;

    private void Start()
    {
        startSpin = false; 
    }

	private void OnEnable()
	{
		spin.action.started += SpinSlot;
	}
	private void OnDisable()
	{
		spin.action.started -= SpinSlot;
	}
	
	private void SpinSlot(InputAction.CallbackContext obj)
	{
		startSpin = true;
		StartCoroutine(Spinning());
	}

	IEnumerator Spinning()
	{
		foreach (Reel reel in reels)
		{
			reel.spin = true;
		}

		for (int i = 0; i < reels.Length; i++)
		{
            yield return new WaitForSeconds(Random.Range(1, 3));
            reels[i].spin = false;
            reels[i].RandomReelSet();
		}

        startSpin = false;
	}
}
