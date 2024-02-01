using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eLOGIN_TYPE 
{ 
    NONE        = 0,
    GUEST       = 1,
    GOOGLE      = 2,
    FACEBOOK    = 3,
    APPLE       = 4,
}

[System.Serializable]
public class GameData_Local : GameData
{
    static GameData_Local m_instance;
    public static GameData_Local Instance 
    { 
        get 
        { 
            if( null == m_instance )
                m_instance = GameDataManager.Instance.GetGameData<GameData_Local>();
            return m_instance;
        } 
    }    

    [SerializeField] bool m_isAgree;
    [SerializeField] bool m_isPush;
    [SerializeField] eLOGIN_TYPE m_loginType;

    public bool isAgree { get { return m_isAgree; } }
    public bool isPush { get { return m_isPush; } }
    public eLOGIN_TYPE loginType { get { return m_loginType; } }
     
    public void SetLoginType( eLOGIN_TYPE _loginType)
    {
        m_loginType = _loginType;
        SaveNotify();
    }
    public void SetAgree( bool _isAgree )
    {
        m_isAgree = _isAgree;
        SaveNotify();
    }

    public void SetPush(bool _isPush)
    {
        m_isPush = _isPush;
        SaveNotify();
    }
    public override void Init()
    {
        base.Init();
        m_loginType = eLOGIN_TYPE.NONE;
        m_isAgree = false;
        m_isPush = false;
    }
}
