using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace NUMC.Setting
{
    public static class Json
    {
        //public static string Convert(object obj)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return serializer.Serialize(obj);
        //}

        //public static T Convert<T>(string json)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return serializer.Deserialize<T>(json);
        //}

        public static string Convert(object obj)
        {
            var serializer = new DataContractJsonSerializer(obj?.GetType());
            using (var ms = new MemoryStream()) {
                serializer.WriteObject(ms, obj);
                var json = Encoding.UTF8.GetString(ms.ToArray());
                Debug.WriteLine($"json convert\to:\t{obj?.GetType()}\tj:\t{json}");
                return json;
            }
        }

        public static T Convert<T>(string json) => (T)Convert(json, typeof(T));

        public static object Convert(string json, Type type)
        {
            Debug.WriteLine($"json convert\tt:\t{type}\tj:\t{json}");
            var serializer = new DataContractJsonSerializer(type);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                return serializer.ReadObject(ms);
        }

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

            for (int i = 0; i < json.Length; i++) {
                key = json[i];

                if (key == '"')
                    str ^= true;

                if (str || (key != ' ' && key != '\n'))
                    sb.Append(key);
            }

            str = false;
            json = sb.ToString();

            sb.Clear();

            for (int i = 0; i < json.Length; i++) {
                writed = false;
                key = json[i];

                if (remove_schedule > 0) {
                    remove_schedule--;
                    continue;
                }

                if (key == '"')
                    str ^= true;

                if (!str) {
                    if (key == '\n') // NewLine시 설정 초기화
                        AppendTab(tab_index, tab, sb);
                    else if (key == '[') { // 배열
                        writed = true;
                        sb.Append(key);
                        tab_index++;

                        sb.AppendLine();
                        AppendTab(tab_index, tab, sb);
                    }
                    else if (key == '{') { // 데이터 들여 쓰기
                        writed = true;
                        sb.Append(key);

                        tab_index++;
                        sb.AppendLine();
                        AppendTab(tab_index, tab, sb);
                    }
                    else if (key == ']') { // 배열 끝내기
                        tab_index--;
                        sb.AppendLine();
                        AppendTab(tab_index, tab, sb);
                    }
                    else if (key == '}') { // 데이터 끝내기
                        tab_index--;
                        sb.AppendLine();
                        AppendTab(tab_index, tab, sb);
                    }
                    else if (key == ',') { //콤마 NewLine
                        writed = true;
                        sb.Append(key);
                        sb.AppendLine();
                        AppendTab(tab_index, tab, sb);
                    }
                    else if (key == ':') { // 데이터 등호 띄어쓰기
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

        private static void AppendTab(int count, string tab, StringBuilder builder) {
            for (int ti = 0; ti < count; ti++) builder.Append(tab);
        }
    }
}