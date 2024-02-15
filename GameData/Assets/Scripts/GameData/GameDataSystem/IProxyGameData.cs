
/**
 * @brief IProxyGameData
 * @detail 게임데이터의 저장 및 로딩 등의 기능을 대신해 주는 인터페이스
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
