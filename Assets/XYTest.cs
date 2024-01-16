using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYTest : MonoBehaviour
{
    static public float chartBarHeight;
    static public Material testPink = Resources.Load<Material>("MyMaterials/TestPink");
    static public bool showAll = false;


    // 1. Oil | 2. Gas | 3. Renewable | 4. Nuclear | 5. Solid fossil fules | 6. Other
    static public float[] uk = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] spain = { 45.7f, 23.4f, 16.3f, 11.7f, 2.9f, 0.0f }; //check 
    static public float[] portugal = { 44.2f, 22.4f, 29.9f, 0.0f, 1.7f, 1.8f }; // check 
    static public float[] france = { 22.8f, 15.2f, 12.7f, 40.7f, 4.2f, -1.6f }; // check
    static public float[] germany = { 33.4f, 26.3f, 15.6f, 6.0f, 19.3f, -0.6f }; // check
    static public float[] italy = { 34.3f, 40.0f, 19.1f, 0.0f, 4.3f, 2.3f }; // check
    static public float[] ireland = { 47.8f, 30.2f, 11.3f, 0.0f, 9.7f, 1.0f }; // liefert nur nach UK
    static public float[] bulgaria = { 24.0f, 14.7f, 15.0f, 22.2f, 27.7f, -3.6f }; // check
    static public float[] romania = { 30.7f, 29.0f, 18.6f, 8.3f, 12.8f, 0.6f }; // check
    static public float[] slovakia = { 21.0f, 25.6f, 13.1f, 22.8f, 17.2f }; // check
    static public float[] greece = { 51.5f, 23.4f, 16.5f, 0.0f, 7.4f, 1.2f }; // check
    static public float[] hungary = { 29.6f, 33.9f, 11.8f, 14.7f, 5.9f, 4.1f }; // check
    static public float[] serbia = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] sweden = { 24.0f, 2.0f, 48.2f, 24.7f, 5.4f, -4.3f }; // check
    static public float[] finland = { 22.2f, 6.3f, 40.3f, 16.5f, 9.8f, 4.9f }; // check
    static public float[] estonia = { 3.8f, 8.5f, 26.9f, 0.0f, 56.2f, 4.6f }; // check
    static public float[] latvia = { 35.6f, 20.1f, 39.8f, 0.0f, 1.4f, 3.1f }; // check
    static public float[] lithuania = { 38.0f, 23.1f, 23.0f, 0.0f, 3.4f, 12.5f }; // check
    static public float[] belarus = { 0, 0, 0, 0, 0, 0 }; // KeineEU
    static public float[] croatia = { 34.1f, 27.9f, 28.8f, 0.0f, 5.3f, 3.9f }; // check
    static public float[] slovenia = { 34.4f, 11.7f, 19.0f, 20.4f, 14.9f, -0.4f }; // check
    static public float[] poland = { 28.8f, 16.6f, 11.9f, 0.0f, 42.7f, 0.0f }; // check
    static public float[] denmark = { 37.2f, 11.1f, 40.4f, 0.0f, 8.9f, 2.4f }; // check
    static public float[] belgium_luxembourg = { 44.9f, 23.7f, 8.0f, 19.0f, 5.1f, -0.7f }; //check
    static public float[] austria = { 34.7f, 22.6f, 31.3f, 0.0f, 9.4f, 2.0f }; // check
    static public float[] czechrepublic = { 22.1f, 18.2f, 12.9f, 17.9f, 31.1f, -2.2f }; // check
    static public float[] netherlands = { 46.2f, 35.3f, 9.5f, 1.0f, 7.7f, 0.3f }; // check

    /*
    static public float[] spain_portugal = { 4698 }; // 9543.5
    static public float[] spain_france = { 595 };

    static public float[] portugal_spain = { 3767 }; // 4791.1f

    static public float[] france_italy = { 16126 };
    static public float[] france_spain = { 850 };
    static public float[] france_germay = { 15653 };
    static public float[] france_belgium = { 8512 }; // Wegen Belgien

    static public float[] germany_austria = { 7386 };
    static public float[] germany_netherland = { 16684 };
    static public float[] germany_poland = { 2005 };
    static public float[] germany_czechia = { 231 };
    static public float[] germany_france = { 407 };
    //static public float[] germany_denmark = { 545 }; // neu
    //static public float[] germany_sweden = { 92 }; // neu

    static public float[] italy_france = { 404 };
    static public float[] italy_greece = { 123 }; // weg
    static public float[] italy_slovenia = { 72 };
    static public float[] italy_austria = { 12.4f }; // weg

    static public float[] ireland_uk = { 71 };

    static public float[] bulgaria_serbia = { 891 };
    static public float[] bulgaria_romania = { 315 };
    static public float[] bulgaria_greece = { 1076 };

    static public float[] romania_hungary = { 1 };
    static public float[] romania_bulgaria = { 443 };

    static public float[] slovakia_hungary = { 7400 };
    static public float[] slovakia_czechia = { 1247 };
    static public float[] slovakia_poland = { 2 }; // weg

    static public float[] greece_italy = { 7 }; // weg
    static public float[] greece_bulgaria = { 205 };

    static public float[] hungary_croatia = { 4472 };
    static public float[] hungary_romania = { 94 }; //weg
    static public float[] hungary_austria = { 842 };
    static public float[] hungary_serbia = { 0 };
    static public float[] hungary_slovakia = { 102 }; // weg

    static public float[] sweden_finland = { 8234 };
    static public float[] sweden_denmark = { 3392 };
    static public float[] sweden_lithuania = { 3445 };
    static public float[] sweden_poland = { 425 };
    static public float[] sweden_norway = { 915 };
    static public float[] sweden_germany = { 664 };

    static public float[] finland_estonia = { 6691 }; // weg
    static public float[] finland_norway = { 173 };
    static public float[] finland_sweden = { 153 };

    static public float[] estonia_lativa = { 929 };
    static public float[] estonia_finland = { 288 }; // weg

    static public float[] lativa_lithuania = { 52 };
    static public float[] lativa_estonia = { 133 };

    static public float[] lithuania_poland = { 1684.5f }; // weg
    static public float[] lithuania_lativa = { 1616 };
    static public float[] lithuania_sweden = { 253.2f }; // weg

    static public float[] croatia_slovenia = { 82 };
    static public float[] croatia_hungary = { 774.3f };
    static public float[] croatia_serbia = { 275.6f };

    static public float[] slovenia_italy = { 1670 };
    static public float[] slovenia_croatia = { 2607 };
    static public float[] slovenia_austria = { 1276 };

    static public float[] poland_czechia = { 7219 };
    static public float[] poland_slovakia = { 1702 };
    static public float[] poland_lithuania = { 695.6f }; // weg
    static public float[] poland_germany = { 688 };
    static public float[] poland_sweden = { 54 };

    static public float[] denmark_germany = { 5993 };
    static public float[] denmark_netherland = { 635 }; //weg
    static public float[] denmark_sweden = { 1616 };
    static public float[] denmark_norway = { 143 };


    static public float[] belgiumLuxembourg_france = { 201 };
    static public float[] belgiumLuxembourg_netherlands = { 5151 };
    static public float[] belgiumLuxembourg_germany = { 123 }; // weg

    static public float[] austria_germany = { 5410 };
    static public float[] austria_slovenia = { 3235 };
    static public float[] austria_hungary = {426};
    static public float[] austria_italy = { 1945 };
    static public float[] austria_czechia = { 2 };

    static public float[] czechrepublic_austria = { 5481 };
    static public float[] czechrepublic_slovakia = { 4265 };
    static public float[] czechrepublic_germany = { 8932 };
    static public float[] czechrepublic_poland = { 64 };

    static public float[] netherlands_germany = { 975 };
    static public float[] netherlands_belgium = { 3045 };
    static public float[] netherlands_denmark = { 671 }; // weg
    //static public float[] netherlands_sweden = { 2 }; // neu
    */

    //Neue Daten
    static public float[] spain_portugal = { 4698 }; // 9543.5
    static public float[] spain_france = { 595 };

    static public float[] portugal_spain = { 3767 }; // 4791.1f

    static public float[] france_italy = { 442 };
    static public float[] france_spain = { 42 };
    static public float[] france_germay = { 4200 };
    static public float[] france_belgium = { 42 }; // Wegen Belgien

    static public float[] germany_austria = { 042 };
    static public float[] germany_netherland = { 42 };
    static public float[] germany_poland = { 4242 };
    static public float[] germany_czechia = { 42420 };
    static public float[] germany_france = { 42 };
    //static public float[] germany_denmark = { 545 }; // neu
    //static public float[] germany_sweden = { 92 }; // neu

    static public float[] italy_france = { 404 };
    static public float[] italy_greece = { 123 }; // weg
    static public float[] italy_slovenia = { 72 };
    static public float[] italy_austria = { 12 }; // weg

    static public float[] ireland_uk = { 71 };

    static public float[] bulgaria_serbia = { 891 };
    static public float[] bulgaria_romania = { 315 };
    static public float[] bulgaria_greece = { 1076 };

    static public float[] romania_hungary = { 1 };
    static public float[] romania_bulgaria = { 443 };

    static public float[] slovakia_hungary = { 7400 };
    static public float[] slovakia_czechia = { 1247 };
    static public float[] slovakia_poland = { 2 }; // weg

    static public float[] greece_italy = { 7 }; // weg
    static public float[] greece_bulgaria = { 205 };

    static public float[] hungary_croatia = { 4472 };
    static public float[] hungary_romania = { 94 }; //weg
    static public float[] hungary_austria = { 842 };
    static public float[] hungary_serbia = { 765 };
    static public float[] hungary_slovakia = { 102 }; // weg

    static public float[] sweden_finland = { 8234 };
    static public float[] sweden_denmark = { 3392 };
    static public float[] sweden_lithuania = { 2556 };
    static public float[] sweden_poland = { 425 };
    static public float[] sweden_norway = { 915 };
    static public float[] sweden_germany = { 664 };

    static public float[] finland_estonia = { 7 }; // weg
    static public float[] finland_norway = { 173 };
    static public float[] finland_sweden = { 153 };

    static public float[] estonia_lativa = { 929 };
    static public float[] estonia_finland = { 1558 }; // weg

    static public float[] lativa_lithuania = { 52 };
    static public float[] lativa_estonia = { 227 };

    static public float[] lithuania_poland = { 14 }; // weg
    static public float[] lithuania_lativa = { 1616 };
    static public float[] lithuania_sweden = { 122 }; // weg

    static public float[] croatia_slovenia = { 82 };
    static public float[] croatia_hungary = { 21 };
    static public float[] croatia_serbia = { 275.6f };

    static public float[] slovenia_italy = { 1670 };
    static public float[] slovenia_croatia = { 2607 };
    static public float[] slovenia_austria = { 1276 };

    static public float[] poland_czechia = { 42 };
    static public float[] poland_slovakia = { 4242 };
    static public float[] poland_lithuania = { 42 }; // weg
    static public float[] poland_germany = { 420 };
    static public float[] poland_sweden = { 042 };

    static public float[] denmark_germany = { 42 };
    static public float[] denmark_netherland = { 4242 }; //weg
    static public float[] denmark_sweden = { 424242 };
    static public float[] denmark_norway = { 0042 };


    static public float[] belgiumLuxembourg_france = { 201 };
    static public float[] belgiumLuxembourg_netherlands = { 5151 };
    static public float[] belgiumLuxembourg_germany = { 123 }; // weg

    static public float[] austria_germany = { 4242 };
    static public float[] austria_slovenia = { 4200 };
    static public float[] austria_hungary = { 42 };
    static public float[] austria_italy = { 0042 };
    static public float[] austria_czechia = { 424242 };

    static public float[] czechrepublic_austria = { 42 };
    static public float[] czechrepublic_slovakia = { 0042 };
    static public float[] czechrepublic_germany = { 42000 };
    static public float[] czechrepublic_poland = { 42 };

    static public float[] netherlands_germany = { 42000 };
    static public float[] netherlands_belgium = { 4242 };
    static public float[] netherlands_denmark = { 424242 }; // weg
    //static public float[] netherlands_sweden = { 2 }; // neu



    // static plublic float spainLands = {};
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
