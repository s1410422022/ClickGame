
[System.Serializable]//讓這個類別可以出現在com
public class EnemyData {

	public int health;
	public int willDropItemId;
	public float dropProbability;
	public float defeatTimeLimit;
	public EnemyBehavior enemyPrefab;

}
