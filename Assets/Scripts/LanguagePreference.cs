using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguagePreference
{
    private static bool language = true;

    public static bool isEnglish
    {
        get { return language; }
        set { language = value; }
    }
}
