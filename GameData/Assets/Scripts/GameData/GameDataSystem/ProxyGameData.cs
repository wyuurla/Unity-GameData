using UnityEngine;

/**
 * @brief ProxyGameData
 * @detail GameData를 저장 또는 불러오는 기능을 대리한다.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class ProxyGameData<TGameData> : IProxyGameData where TGameData : GameData, new()
{
    protected TGameData m_gameData; //게임데이터.
    protected string m_filePath;    //저장된 파일 경로.

    /**
     * GameData를 리턴한다.
     */
    public GameData GetGameData() { return m_gameData; }

    /**
     * _filiePath가 null이면 저장하지 않는다. 서버의 데이터만 받아서 사용할때 null을 넣는다.
     */
    public ProxyGameData(string _filiePath)
    {
        m_filePath = _filiePath;
    }

    /**
     * 파일이 존재하지 않을때 게임데이터를 생성한다.
     */
    public void Init()
    {
        m_gameData = new TGameData();
        m_gameData.Init();
    }
    
    /**
     *  m_filePath의 경로로 파일을 로드한다. 파일이 없다면 기본 게임데이터로 생성한다.
     */
    public void Load()
    {
        if (string.IsNullOrWhiteSpace(m_filePath) == true)
        {
            Init();
            return;
        }

        try
        {
            string _fileData = FileUtil.Load(m_filePath);
            m_gameData = JsonUtility.FromJson<TGameData>(_fileData);
            if (null == m_gameData)            
                Init();
        }
        catch (System.Exception _e)
        {
            Init();
            Debug.LogError("JsonUtility.FromJson() : " + _e.ToString());
        }
    }

    /**
     *  m_filePath의 경로로 파일을 저장한다.
     */
    public void Save()
    {
        if (null == m_gameData)
            return;

        if (string.IsNullOrWhiteSpace(m_filePath) == true)
            return;

        try
        {
            string _data = JsonUtility.ToJson(m_gameData);
            if (FileUtil.Save(m_filePath, _data) == false)
            {
                Debug.LogError("save failed : " + m_filePath);
                return;
            }
        }
        catch (System.Exception _e)
        {
            Debug.LogError("JsonUtility.FromJson() : " + _e.ToString());
        }
    }

    /**
     *  파일을 로드후 처리해야 하는 로직을 실행한다. 
     *  출석보상에서 다음날 처리해야 하는 경우.
     */
    public void Check()
    {
        if (null == m_gameData)
            return;

        m_gameData.Check();
    }

    /**
     *  계정전화, 데이터 초기화때 사용한다.
     */
    public void Logout()
    {
        if (null == m_gameData)
            return;

        m_gameData.Logout();
    }

    /**
     *  isSave가 true이면 게임 데이터를 저장한다.
     */
    public void UpdateLogic()
    {
        if (null == m_gameData)
            return;

        if (m_gameData.isSave)
        {
            Save();
            m_gameData.SetSave(false);
        }

        m_gameData.UpdateNotify();
        m_gameData.UpdateLogic();
    }
}