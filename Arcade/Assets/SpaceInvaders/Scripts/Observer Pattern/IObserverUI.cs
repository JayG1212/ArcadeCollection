
namespace SpaceInvaders
{
    public interface IObserverUI
    {
        void OnGameStateChanged(int score, int health);
    }
}