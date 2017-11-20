namespace imbSCI.Core.interfaces
{
    using System;

    public interface IAceLogable:ILogable
    {

       void log(String message);

       String logContent
       {
           get;
           
       }
    }
}
