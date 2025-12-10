public interface IPlayerStorage
{
    void Save(Player player);
    Player Load();
}