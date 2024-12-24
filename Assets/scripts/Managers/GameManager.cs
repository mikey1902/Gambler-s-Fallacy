using UnityEngine;

public enum GameState
{
	START,
	PLAYER,
	ENEMY,
	WON,
	LOST
}

public class GameManager : MonoBehaviour
{
	public GameState gameState;
	public static GameManager Instance { get; private set; }
	public CardManager cardManager { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			InitializeManagers();
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}
	private void InitializeManagers()
	{
		cardManager = GetComponentInChildren<CardManager>();
		if (cardManager == null)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/CardManager");
			if (prefab == null) { Debug.Log($"CardManager prefab not found"); }
			else
			{
				Instantiate(prefab, transform.position, Quaternion.identity, transform);
				cardManager = GetComponentInChildren<CardManager>();
			}
		}
	}
	private void Start()
	{
		gameState = GameState.START;
		SetupCombat();
	}

	private void SetupCombat()
	{
		gameState = GameState.PLAYER;
	}
	public void StartPlayerTurn()
	{
		gameState = GameState.PLAYER;
	}
	public void StartEnemyTurn()
	{
		gameState = GameState.ENEMY;
	}
}