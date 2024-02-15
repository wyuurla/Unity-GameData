/**
 * @brief GameData
 * @detail  게임데이터 상위 클래스. 저장이 필요할때 Save()함수 사용. 
 *          옵저버에게 변경된 내용이 있음을 알려줄때는 Notify()함수를 사용한다.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class GameData : Subject
{
    private bool m_isSave;

    public bool isSave { get { return m_isSave; } }

    /**
     * 저장된 파일이 없을때 한번 호출된다.
     */
    public virtual void Init()
    {
    }

    /**
     * 계정전환이나 초기화할때 초기화가 필요한 내용을 입력한다.
     */
    public virtual void Logout()
    {
        Init();
    }

    /**
     * 파일을 로딩후에 체크(출석보상 날자초기화 로직)해야 되는경우 사용한다.
     */
    public virtual void Check()
    {
    }

    /**
     * 
     */
    public virtual void UpdateLogic()
    {
    }

    /**
     * 게임데이터를 저장한다. 옵저버에게 통보한다.
     */
    public void SaveNotify()
    {
        Save();
        Notify();
    }

    /**
     * 게임데이터 저장 필요상태로 설정한다.
     */
    public void Save()
    {
        SetSave(true);
    }

    /**
     * 게임데이터 저장 필요상태를 설정한다.
     */
    public void SetSave(bool _isSave)
    {
        m_isSave = _isSave;
    }
}