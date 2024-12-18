using UnityEngine;

public class Position : MonoBehaviour
{
	public Slots slots;

	private void Awake()
	{
		slots = FindFirstObjectByType<Slots>();
	}
}
