using UnityEngine;

[System.Serializable]
public class GameData_Option : GameData 
{
	static GameData_Option m_instance;
	public static GameData_Option Instance { get { if (m_instance == null) { m_instance = GameDataManager.Instance.GetGameData<GameData_Option>(); } return m_instance; } }

	public float sound_volume_bgm;
	public float sound_volume_fx;
	public SystemLanguage language;

	public override void Init()
	{
		base.Init();
		sound_volume_bgm = 1f;
		sound_volume_fx = 1f;
		language = Application.systemLanguage;
	}

	public void SetSound_volume_bgm(float _value)
	{
		sound_volume_bgm = Mathf.Clamp(_value, 0f, 1f);
		SaveNotify();
	}
	public void SetSound_volume_fx(float _value)
	{
		sound_volume_fx = Mathf.Clamp(_value, 0f, 1f);
		SaveNotify();
	}

	public void SetLanguage(SystemLanguage _language)
	{
		language = _language;
		SaveNotify();
	}
}

