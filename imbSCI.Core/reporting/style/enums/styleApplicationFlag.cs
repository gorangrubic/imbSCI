namespace imbSCI.Core.reporting.style.enums
{
    using System;

    [Flags]
    public enum styleApplicationFlag
    {
        none=0,
        enableTextShot=1,
        enableContentShot=2,
        enableColorShot=4,
        allShots=7,
        customizedStyle=8,
        autoByRole=16,
        //autoByType=32,
        autoByVariator=64,
        //autoByTableVariator=128,
      //  autoByPairsVariator=256,
       // autoBySectionVariator=512,
        setAsActive = 1024,



    }

}