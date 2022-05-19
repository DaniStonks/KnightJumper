using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguagePreference
{
    public static bool isEnglish = true;

    public static bool language
    {
        get { return isEnglish; }
        set { isEnglish = value; }
    }
}
