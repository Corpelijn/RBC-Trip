using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder
{
    public enum BloedLocatie
    {
        left_Ventricle          = -1,
        right_Ventricle         = -2,
        Brain                   = -3,
        right_Pulmonary_Artery  = -4,
        left_Pulmonary_Artery   = -5,
        Stomach                 = -7,
        Liver                   = -6,
        Colon                   = -8,
        right_Kidney            = -10,
        left_Kidney             = -9,

        Common_Carotid_Artery   = 0,
        Gastric_Artery          = 1,
        Hepatic_Artery          = 2,
        Inferior_Mesenteric_Artery  = 3,
        Renal_Artery            = 4,

        Renal_Veins             = 5,
        Hepatic_Vein            = 6,
        Gastric_Vein            = 7,
        Common_Carotid_Vein     = 8,

        Pulmonary_Artery        = 9,
        Pulmonary_Vein          = 10
    }
}
