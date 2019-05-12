using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCharacter
{

    private string str_char;
    public string StrChar {
        get {
            return str_char;
        }
    }

    private string meaning;
    public string Meaning {
        get {
            return meaning;
        }
    }

    private string flat_pinying;
    public string FlatPinying {
        get {
            return flat_pinying;
        }
    }

    private int tone;
    public int Tone {
        get {
            return tone;
        }
    }

    public ShooterCharacter(string str_char, string meaning, string flat_pinying, int tone) {
        this.str_char = str_char;
        this.meaning = meaning;
        this.flat_pinying = flat_pinying;
        this.tone = tone;
    }
}
