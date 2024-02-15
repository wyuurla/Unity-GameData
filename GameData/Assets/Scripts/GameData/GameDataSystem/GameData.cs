/**
 * @brief GameData
 * @detail  ���ӵ����� ���� Ŭ����. ������ �ʿ��Ҷ� Save()�Լ� ���. 
 *          ���������� ����� ������ ������ �˷��ٶ��� Notify()�Լ��� ����Ѵ�.
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public class GameData : Subject
{
    private bool m_isSave;

    public bool isSave { get { return m_isSave; } }

    /**
     * ����� ������ ������ �ѹ� ȣ��ȴ�.
     */
    public virtual void Init()
    {
    }

    /**
     * ������ȯ�̳� �ʱ�ȭ�Ҷ� �ʱ�ȭ�� �ʿ��� ������ �Է��Ѵ�.
     */
    public virtual void Logout()
    {
        Init();
    }

    /**
     * ������ �ε��Ŀ� üũ(�⼮���� �����ʱ�ȭ ����)�ؾ� �Ǵ°�� ����Ѵ�.
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
     * ���ӵ����͸� �����Ѵ�. ���������� �뺸�Ѵ�.
     */
    public void SaveNotify()
    {
        Save();
        Notify();
    }

    /**
     * ���ӵ����� ���� �ʿ���·� �����Ѵ�.
     */
    public void Save()
    {
        SetSave(true);
    }

    /**
     * ���ӵ����� ���� �ʿ���¸� �����Ѵ�.
     */
    public void SetSave(bool _isSave)
    {
        m_isSave = _isSave;
    }
}