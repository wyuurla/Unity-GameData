using System.Collections.Generic;
using UnityEngine;

/**
 * @brief GameDataManager
 * @detail GameData�� �����ϴ� Ŭ����.
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
     * GameDataCreate ���丮 Ŭ������ ����Ͽ� ������ Ŭ������ �������� �ε��Ѵ�.
     */
    public void Init()
    {
        GameDataCreate _create = new GameDataCreate_Local();
        m_dataList = _create.Create();
        Load();
    }

    /**
     * ���ӵ����͸� ���Ϸ� ���� �ε��Ѵ�. Init�Լ����� �ʱ�ȭ �Ҷ� �ε��ϱ⶧���� Ư���� ��찡 �ƴϸ� ������� �ʴ´�.
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
     * ������ �ε��Ŀ� üũ(�⼮���� ���� �ʱ�ȭ�� �ʿ��� ��� ����)�ؾ� �Ǵ°�� ����Ѵ�. 
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
     * ���� �����͸� �����Ѵ�. ������ ���������� ó���ϱ� ������ Ư���� ��찡 �ƴϸ� ������� �ʴ´�.
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
     * ������ȯ�̳� �ʱ�ȭ�Ҷ� �ʱ�ȭ �Ҷ� ����Ѵ�.
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
     * UpdateLogic()�� Update()�Լ��� �� ȣ������� �Ѵ�.
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
     * GameData�� �����Ѵ�.
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
