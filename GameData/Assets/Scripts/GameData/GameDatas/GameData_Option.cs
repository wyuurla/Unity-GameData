[System.Serializable]
public class GameData_Option : GameData 
{
	static GameData_Option m_instance;
	public static GameData_Option Instance { get { if (m_instance == null) { m_instance = GameDataManager.Instance.GetGameData<GameData_Option>(); } return m_instance; } }

	public float sound_volume_bgm;
	public float sound_volume_fx;
	public override void Init()
	{
		base.Init();
		sound_volume_bgm = 1f;
		sound_volume_fx = 1f;
	}
}

