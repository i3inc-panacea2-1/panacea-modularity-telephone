using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Telephone
{
    public interface ITelephoneAccount
    {
        string Username { get; }

        string Password { get; }

        string Server { get; }

        string DisplayNumber { get; set; }

        string VoipType { get; set; }

    }
}

