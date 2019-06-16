using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCharacter
{

    private int chapter;
    public int Chapter {
        get {
            return chapter;
        }
    }

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

    private string tone;
    public string Tone {
        get {
            return tone;
        }
    }

    public string AsString {
        get {
            return StrChar + " " + FlatPinying + Tone + " " + Meaning;
        }
    }

    public ShooterCharacter(string str_char, string meaning, string flat_pinying, string tone, int chapter) {
        this.str_char = str_char;
        this.meaning = meaning;
        this.flat_pinying = flat_pinying;
        this.tone = tone;
        this.chapter = chapter;
    }
}
