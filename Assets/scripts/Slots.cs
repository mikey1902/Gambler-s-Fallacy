using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slots : MonoBehaviour
{
    public Reel[] reels;
    public Reel[] resultReels;
	public GameObject[] slotGrid;
    public InputActionReference spin;
    bool startSpin;
	public DeckManager deckManager;
    private void Start()
    { 
		deckManager = FindFirstObjectByType<DeckManager>();
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
		if (startSpin == false) {StartCoroutine(Spinning());}
	}

	IEnumerator Spinning()
	{
		startSpin = true;

		foreach (Reel reel in reels)
		{
			reel.spin = true;
			reel.EnableReel();
		}

		for (int i = 0; i < reels.Length; i++)
		{
            yield return new WaitForSeconds(Random.Range(1, 3));
            reels[i].spin = false;
		}
		foreach (Reel reel in reels)
		{
			reel.DisableReel();
		}
		startSpin = false;
		GenerateResult();
		//ResultCheck();
	}
	private void GenerateResult()
	{
		foreach(Reel reel in resultReels)
		{
			reel.RandomizeReel();
		}
	}
	private void ResultCheck()
	{
		Debug.Log("sigma");
		foreach (Reel reel in reels)
		{
			for (int i = 0; i < reel.positionsInReel.Count; i++)
			{
				Debug.Log(reel.positionsInReel[i]);
			}
		}
	}
}
