using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    class LoadCharacters {

        public static List<ShooterCharacter> LoadLearningChineseCharacters() {

            var char_list = new List<ShooterCharacter>();

            char_list.Add(new ShooterCharacter("一", "one", "yi", "1"));
            char_list.Add(new ShooterCharacter("二", "two", "er", "4"));
            char_list.Add(new ShooterCharacter("三", "three", "san", "1"));
            char_list.Add(new ShooterCharacter("十", "ten", "shi", "2"));
            char_list.Add(new ShooterCharacter("口", "mouth", "kou", "3"));
            char_list.Add(new ShooterCharacter("日", "sun", "ri", "4"));
            char_list.Add(new ShooterCharacter("几", "number of", "ji", "3"));
            char_list.Add(new ShooterCharacter("也", "also", "ye", "3"));
            char_list.Add(new ShooterCharacter("不", "not", "bu", "4"));
            char_list.Add(new ShooterCharacter("机", "machine", "ji", "1"));

            char_list.Add(new ShooterCharacter("杯", "cup", "bei", "1"));
            char_list.Add(new ShooterCharacter("人", "person", "ren", "2"));
            char_list.Add(new ShooterCharacter("他", "he", "ta", "1"));
            char_list.Add(new ShooterCharacter("力", "power", "li", "4"));
            char_list.Add(new ShooterCharacter("女", "woman", "nü", "3"));
            char_list.Add(new ShooterCharacter("她", "her", "ta", "1"));

            char_list.Add(new ShooterCharacter("我", "me", "wo", "3"));

            return char_list;
        }
    }
}
