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
	public CardManager CardManager { get; private set; }
	public EnemyManager EnemyManager { get; private set; }

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
		CardManager = GetComponentInChildren<CardManager>();
		if (CardManager == null)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/CardManager");
			if (prefab == null) { Debug.Log($"CardManager prefab not found"); }
			else
			{
				Instantiate(prefab, transform.position, Quaternion.identity, transform);
				CardManager = GetComponentInChildren<CardManager>();
			}
		}
		EnemyManager = GetComponentInChildren<EnemyManager>();
		if (CardManager == null)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/EnemyManager");
			if (prefab == null) { Debug.Log($"EnemyManager prefab not found"); }
			else
			{
				Instantiate(prefab, transform.position, Quaternion.identity, transform);
				EnemyManager = GetComponentInChildren<EnemyManager>();
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
		EnemyManager.EnemyTurns();
		Debug.Log("Enemy Turn Start");
	}
}