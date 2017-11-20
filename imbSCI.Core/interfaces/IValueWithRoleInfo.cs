namespace imbSCI.Core.interfaces
{
    using System;

    public interface IValueWithRoleInfo
    {
        String role_name { get; set; }
        String role_symbol { get; set; }
        String role_letter { get; set; }
    }


}