using System;
using System.Collections.Generic;
using System.Linq;

using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;


namespace imbSCI.Data.enums
{

    public enum onErrorPolicy
    {
        none,
        unknown,
        onErrorContinue,
        onErrorStop,
        onErrorThrowException,
    }

}