using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using  ROASApplication.Data;

namespace ROASApplication.Business
{
   public class ROASService
    { 
        private static List<ROAS> list=new List<ROAS>();
        public static void SaveROAS(ROAS roas)
        {
            GetROASList();
            list.Add(roas);
            string json=JsonSerializer.Serialize(list,new JsonSerializerOptions { IncludeFields=true});

            FileOperations.Write(json);
        }
        public static IReadOnlyCollection<ROAS> GetROASList() 
        {
            string json = FileOperations.Read();

            list = JsonSerializer.Deserialize<List<ROAS>>(json, new JsonSerializerOptions { IncludeFields = true });
            return list.AsReadOnly();
        }

        public static IReadOnlyCollection<ROAS> SearchFromChannelName(string channelName)
        {
            GetROASList();
            var result = new List<ROAS>();
            foreach (var c in list)
            { 
             if(c.channelName==channelName)
                    result.Add(c);
            }
            return list.AsReadOnly();
        }
    }
}
