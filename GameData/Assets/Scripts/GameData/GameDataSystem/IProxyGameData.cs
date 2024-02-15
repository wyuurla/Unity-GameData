
/**
 * @brief IProxyGameData
 * @detail ���ӵ������� ���� �� �ε� ���� ����� ����� �ִ� �������̽�
 * @date 2024-02-01
 * @version 1.0.0
 * @author kij
 */
public interface IProxyGameData
{
    public void Load();
    public void Check();
    public void Save();
    public void Logout();
    public void UpdateLogic();
    public GameData GetGameData();
}
