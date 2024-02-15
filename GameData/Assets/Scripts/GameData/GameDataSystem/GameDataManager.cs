using System.Collections.Generic;
using UnityEngine;

/**
 * @brief GameDataManager
 * @detail GameData를 관리하는 클래스.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class GameDataManager : ClassSingleton<GameDataManager>, IManager
{
    protected Dictionary<System.Type, IProxyGameData> m_dataList;

    public GameDataManager()
    {
        Init();
    }

    /**
     * GameDataCreate 팩토리 클래스를 사용하여 데이터 클래스를 생성한후 로딩한다.
     */
    public void Init()
    {
        GameDataCreate _create = new GameDataCreate_Local();
        m_dataList = _create.Create();
        Load();
    }

    /**
     * 게임데이터를 파일로 부터 로딩한다. Init함수에서 초기화 할때 로딩하기때문에 특별한 경우가 아니면 사용하지 않는다.
     */
    public void Load()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Load();
        }
    }

    /**
     * 파일을 로딩후에 체크(출석보상 날자 초기화가 필요할 경우 로직)해야 되는경우 사용한다. 
     */
    public void Check()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Check();
        }
    }

    /**
     * 게임 데이터를 저장한다. 저장은 내부적으로 처리하기 때문에 특별한 경우가 아니면 사용하지 않는다.
     */
    public void Save()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Save();
        }
    }

    /**
     * 계정전환이나 초기화할때 초기화 할때 사용한다.
     */
    public void Logout()
    {
        var _Var = m_dataList.GetEnumerator();
        while(_Var.MoveNext())
        {
            _Var.Current.Value.Logout();
        }
    }

    /**
     * UpdateLogic()는 Update()함수에 꼭 호출해줘야 한다.
     */
    public void UpdateLogic()
    {
        var _Var = m_dataList.GetEnumerator();
        while (_Var.MoveNext())
        {
            _Var.Current.Value.UpdateLogic();
        }
    }

    /**
     * GameData를 리턴한다.
     */
    public TGameData GetGameData<TGameData>() where TGameData : GameData
    {
        System.Type _key = typeof(TGameData);
        if (null == m_dataList)
        {
            Debug.LogError("GameDataManager::GetData()[ DataList == null ] : " + _key.ToString());
            return null;
        }

        IProxyGameData _proxyGameData;
        if (m_dataList.TryGetValue(_key, out _proxyGameData) == false)
        {
            Debug.LogError("GameDataManager::GetData()[ no Have : " + _key.ToString());
            return null;
        }

        return _proxyGameData.GetGameData() as TGameData;
    }
}
