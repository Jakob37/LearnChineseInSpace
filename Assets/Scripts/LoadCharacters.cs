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

            // Chapter 5
            char_list.Add(new ShooterCharacter("大", "", "", ""));
            char_list.Add(new ShooterCharacter("太", "", "", ""));
            char_list.Add(new ShooterCharacter("夫", "", "", ""));
            char_list.Add(new ShooterCharacter("小", "", "", ""));
            char_list.Add(new ShooterCharacter("你", "", "", ""));
            char_list.Add(new ShooterCharacter("又", "", "", ""));
            char_list.Add(new ShooterCharacter("友", "", "", ""));
            char_list.Add(new ShooterCharacter("地", "", "", ""));
            char_list.Add(new ShooterCharacter("在", "", "", ""));
            char_list.Add(new ShooterCharacter("云", "", "", ""));
            char_list.Add(new ShooterCharacter("运", "", "", ""));
            char_list.Add(new ShooterCharacter("动", "", "", ""));
            char_list.Add(new ShooterCharacter("会", "", "", ""));
            char_list.Add(new ShooterCharacter("国", "", "", ""));
            
            // Chapter 6
            char_list.Add(new ShooterCharacter("月", "", "", ""));
            char_list.Add(new ShooterCharacter("朋", "", "", ""));
            char_list.Add(new ShooterCharacter("有", "", "", ""));
            char_list.Add(new ShooterCharacter("妹", "", "", ""));
            char_list.Add(new ShooterCharacter("来", "", "", ""));
            char_list.Add(new ShooterCharacter("了", "", "", ""));
            char_list.Add(new ShooterCharacter("说", "", "", ""));
            char_list.Add(new ShooterCharacter("语", "", "", ""));
            char_list.Add(new ShooterCharacter("多", "", "", ""));
            char_list.Add(new ShooterCharacter("名", "", "", ""));
            char_list.Add(new ShooterCharacter("外", "", "", ""));
            char_list.Add(new ShooterCharacter("刀", "", "", ""));
            char_list.Add(new ShooterCharacter("分", "", "", ""));
            char_list.Add(new ShooterCharacter("到", "", "", ""));
            char_list.Add(new ShooterCharacter("倒", "", "", ""));

            // Chapter 7
            char_list.Add(new ShooterCharacter("天", "", "", ""));
            char_list.Add(new ShooterCharacter("明", "", "", ""));
            char_list.Add(new ShooterCharacter("汉", "", "", ""));
            char_list.Add(new ShooterCharacter("别", "", "", ""));
            char_list.Add(new ShooterCharacter("如", "", "", ""));
            char_list.Add(new ShooterCharacter("行", "", "", ""));
            char_list.Add(new ShooterCharacter("学", "", "", ""));
            char_list.Add(new ShooterCharacter("车", "", "", ""));
            char_list.Add(new ShooterCharacter("连", "", "", ""));
            char_list.Add(new ShooterCharacter("开", "", "", ""));
            char_list.Add(new ShooterCharacter("去", "", "", ""));
            char_list.Add(new ShooterCharacter("法", "", "", ""));
            char_list.Add(new ShooterCharacter("取", "", "", ""));
            char_list.Add(new ShooterCharacter("千", "", "", ""));
            char_list.Add(new ShooterCharacter("前", "", "", ""));

            // Chapter 8
            char_list.Add(new ShooterCharacter("安", "", "", ""));
            char_list.Add(new ShooterCharacter("字", "", "", ""));
            char_list.Add(new ShooterCharacter("目", "", "", ""));
            char_list.Add(new ShooterCharacter("自", "", "", ""));
            char_list.Add(new ShooterCharacter("咱", "", "", ""));
            char_list.Add(new ShooterCharacter("阳", "", "", ""));
            char_list.Add(new ShooterCharacter("阴", "", "", ""));
            char_list.Add(new ShooterCharacter("那", "", "", ""));
            char_list.Add(new ShooterCharacter("哪", "", "", ""));
            char_list.Add(new ShooterCharacter("西", "", "", ""));
            char_list.Add(new ShooterCharacter("要", "", "", ""));
            char_list.Add(new ShooterCharacter("酒", "", "", ""));
            char_list.Add(new ShooterCharacter("从", "", "", ""));
            char_list.Add(new ShooterCharacter("村", "", "", ""));
            char_list.Add(new ShooterCharacter("时", "", "", ""));
            char_list.Add(new ShooterCharacter("过", "", "", ""));
            char_list.Add(new ShooterCharacter("身", "", "", ""));
            char_list.Add(new ShooterCharacter("谢", "", "", ""));

            // Chapter 9
            char_list.Add(new ShooterCharacter("家", "", "", ""));
            char_list.Add(new ShooterCharacter("山", "", "", ""));
            char_list.Add(new ShooterCharacter("羊", "", "", ""));
            char_list.Add(new ShooterCharacter("样", "", "", ""));
            char_list.Add(new ShooterCharacter("班", "", "", ""));
            char_list.Add(new ShooterCharacter("出", "", "", ""));
            char_list.Add(new ShooterCharacter("础", "", "", ""));
            char_list.Add(new ShooterCharacter("岁", "", "", ""));
            char_list.Add(new ShooterCharacter("但", "", "", ""));
            char_list.Add(new ShooterCharacter("得", "", "", ""));
            char_list.Add(new ShooterCharacter("公", "", "", ""));
            char_list.Add(new ShooterCharacter("以", "", "", ""));
            char_list.Add(new ShooterCharacter("之", "", "", ""));
            char_list.Add(new ShooterCharacter("为", "", "", ""));
            char_list.Add(new ShooterCharacter("办", "", "", ""));
            char_list.Add(new ShooterCharacter("干", "", "", ""));
            char_list.Add(new ShooterCharacter("牛", "", "", ""));
            char_list.Add(new ShooterCharacter("和", "", "", ""));

            // Chapter 10
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 11
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 12
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 13
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 14
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));

            // Chapter 15
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));
            char_list.Add(new ShooterCharacter("", "", "", ""));


        }
    }
}
