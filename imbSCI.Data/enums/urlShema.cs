using System;
using System.Collections.Generic;
using System.Linq;

using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;


namespace imbSCI.Data.enums
{
    /// <summary>
    /// podrzane sheme za URL
    /// </summary>
    public enum urlShema
    {
        none,
        file,
        ftp,
        gopher,
        http,
        https,
        ldap,
        mailto,
        netPipe,
        netTcp,
        news,
        nntp,
        telnet,
        uuid,
        unknown,
    }
}