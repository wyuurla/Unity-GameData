using System.Collections.Generic;
using UnityEngine;

/**
 * @brief GameDataCreate
 * @detail GameData를 생성하는 패토리 클래스
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public abstract class GameDataCreate
{
    /**
     * 게임데이터 리스트를 리턴한다.
     */
    public abstract Dictionary<System.Type, IProxyGameData> Create();

    /**
     * 게임데이터를 리스트에 추가하는 함수, 하위 클래스에서 사용한다.
     */
    protected virtual void Add<TGameData>(Dictionary<System.Type, IProxyGameData> _list, bool _fileSave = true) where TGameData : GameData, new()
    {
        System.Type _key = typeof(TGameData);
        if (_list.ContainsKey(_key) == true)
        {
            Debug.LogError("GameDataManager::AddData() [ have : " + _key.ToString());
            return;
        }

        string _filePath = null;
        if (_fileSave == true)
        {
            _filePath = string.Format("{0}/v{1}.bytes", Application.persistentDataPath, _key.ToString());
        }

        ProxyGameData<TGameData> _proxyGameData = new ProxyGameData<TGameData>(_filePath);
        _list.Add(_key, _proxyGameData);
    }
}

