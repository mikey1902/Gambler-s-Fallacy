using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
	public bool spin;
	public int speed = 1500;

	void Start()
	{
		spin = false;
	}
	void Update()
	{
		if (spin)
		{
			foreach (Transform img in transform)
			{
				img.transform.Translate(Vector2.down * Time.smoothDeltaTime * speed, Space.World);

				if (img.transform.position.y <= 0)
				{
					img.transform.position = new Vector2(img.transform.position.x, img.transform.position.y + 600);
				}
			}
		}
	}

	public void RandomReelSet()
	{
		List<int> reelPos = new List<int>();

		reelPos.Add(200);
		reelPos.Add(100);
		reelPos.Add(0);
		reelPos.Add(-100);
		reelPos.Add(-200);
		reelPos.Add(-300);

		foreach (Transform img in transform)
		{
			int rand = Random.Range(0, reelPos.Count);

			img.transform.position = new Vector2(img.transform.position.x, reelPos[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y);

			reelPos.RemoveAt(rand);
		}
	}
}
