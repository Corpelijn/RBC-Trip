using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder
{
    public enum BloedLocatie
    {
        HartL                   = -1,
        HartR                   = -2,
        Hersenen                = -3,   
        LongL                   = -4,
        LongR                   = -5,
        Maag                    = -7,
        Lever                   = -6,
        Darmen                  = -8,
        NierR                   = -10,
        NierL                   = -9,

        Heen_HersenenHart       = 0,
        Heen_Maag               = 1,
        Heen_Lever              = 2,
        Heen_Darmen             = 3,
        Splitsing_Nieren        = 4,

        Samenkoming_Nieren      = 5,
        Terug_Lever             = 6,
        Terug_Maag              = 7,
        Terug_HersenenHart      = 8,

        Ingang_Longen           = 9,
        Uitgang_Longen          = 10
    }
}
