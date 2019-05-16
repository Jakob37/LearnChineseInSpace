using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    class LoadCharacters {

        public static List<ShooterCharacter> LoadLearningChineseCharacters() {

            var char_list = new List<ShooterCharacter>();

            // Chapter 1
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


            // char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 2

            char_list.Add(new ShooterCharacter("子", "child", "zi", "5"));
            char_list.Add(new ShooterCharacter("好", "good", "hao", "3"));
            char_list.Add(new ShooterCharacter("个", "number of items", "ge", "4"));
            char_list.Add(new ShooterCharacter("八", "eight", "ba", "1"));
            char_list.Add(new ShooterCharacter("儿", "boy", "er", "2"));
            char_list.Add(new ShooterCharacter("白", "white", "bai", "2"));
            char_list.Add(new ShooterCharacter("的", "of", "de", "5"));
            char_list.Add(new ShooterCharacter("四", "four", "si", "4"));

            // Chapter 3
            char_list.Add(new ShooterCharacter("文", "culture", "wen", "2"));
            char_list.Add(new ShooterCharacter("这", "this", "zhe", "4"));
            char_list.Add(new ShooterCharacter("门", "gate", "men", "2"));
            char_list.Add(new ShooterCharacter("们", "people", "men", "5"));
            char_list.Add(new ShooterCharacter("正", "upright", "zheng", "4"));
            char_list.Add(new ShooterCharacter("是", "is", "shi", "4"));
            char_list.Add(new ShooterCharacter("手", "hand", "shou", "3"));
            char_list.Add(new ShooterCharacter("我", "me", "wo", "3"));
            char_list.Add(new ShooterCharacter("中", "middle", "zhong", "1"));

            // Chapter 4
            char_list.Add(new ShooterCharacter("么", "appendage", "me", "5"));
            char_list.Add(new ShooterCharacter("什", "what", "shen", "2"));
            char_list.Add(new ShooterCharacter("五", "five", "wu", "3"));
            char_list.Add(new ShooterCharacter("七", "seven", "qi", "1"));
            char_list.Add(new ShooterCharacter("九", "nine", "jiu", "3"));
            char_list.Add(new ShooterCharacter("六", "six", "liu", "4"));
            char_list.Add(new ShooterCharacter("百", "hundred", "bai", "3"));
            char_list.Add(new ShooterCharacter("边", "side", "bian", "1"));
            char_list.Add(new ShooterCharacter("上", "above", "shang", "4"));
            char_list.Add(new ShooterCharacter("下", "below", "xia", "4"));
            char_list.Add(new ShooterCharacter("马", "horse", "ma", "3"));
            char_list.Add(new ShooterCharacter("吗", "question mark", "ma", "5"));
            char_list.Add(new ShooterCharacter("妈", "mum", "ma", "1"));


            return char_list;
        }
    }
}
