using System.Text;
using System.Text.RegularExpressions;

namespace NUMC.Script
{
    public class Json
    {
        public static string BeautifierJson(string json)
        {
            char key;

            bool str = false; //문자열 여부
            bool writed; // 키가 쓰여졌는지

            int tab_index = 0; // 탭 횟수
            int remove_schedule = 0; // 제거 예약 길이

            string tab = "    "; // 탭 문자열
            string oneTab = " "; // 원 탭 문자열

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < json.Length; i++)
            {
                writed = false;
                key = json[i];

                if (remove_schedule > 0)
                {
                    remove_schedule--;
                    continue;
                }

                if (key == '"')
                    str ^= true;

                if (!str)
                {
                    if (key == '\n') // NewLine시 설정 초기화
                    {
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.AppendLine(tab);
                    }
                    else if (key == '[') // 배열
                    {
                        writed = true;
                        sb.Append(key);
                        tab_index++;

                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                    }
                    else if (key == '{') // 데이터 들여 쓰기
                    {
                        writed = true;
                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                        sb.Append(key);

                        tab_index++;
                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                    }
                    else if (key == ']') // 배열 끝내기
                    {
                        tab_index--;
                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                    }
                    else if (key == '}') // 데이터 끝내기
                    {
                        tab_index--;
                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                    }
                    else if (key == ',') //콤마 NewLine
                    {
                        writed = true;
                        sb.Append(key);
                        sb.AppendLine();
                        for (int ti = 0; ti < tab_index; ti++)
                            sb.Append(tab);
                    }
                    else if (key == ':') // 데이터 등호 띄어쓰기
                    {
                        writed = true;
                        sb.Append(key);
                        sb.Append(oneTab);
                    }
                }

                if (!writed)
                    sb.Append(key);
            }

            return Regex.Replace(sb.ToString(), @"^\s+$[\r\n]*", "", RegexOptions.Multiline); // 빈 줄 제거
        }
    }
}