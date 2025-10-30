using BookcrossingApp.Models;
using BookcrossingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp
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
