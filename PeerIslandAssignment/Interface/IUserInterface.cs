using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslandAssignment.Interface
{
    public interface IUserInterface
    {
        public void ShowStart();

        public void ShowSummary(int option, bool isSuccess, int resultCount = 0);
    }
}
