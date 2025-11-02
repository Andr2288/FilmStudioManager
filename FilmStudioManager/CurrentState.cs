using FilmStudioManager.Models;

namespace FilmStudioManager
{
    public class CurrentState
    {
        private static CurrentState _instance;
        private static readonly object _lock = new object();

        public User User = null;

        private CurrentState()
        {

        }

        public static CurrentState GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CurrentState();
                    }
                }
            }

            return _instance;
        }
    }
}
