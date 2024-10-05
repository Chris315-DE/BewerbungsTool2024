using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Manager
{
    public class LebenslaufTemplateLoader
    {

        private string _Folder;

        public List<LebenslaufTemplate> GeladeneTemplates { get; set; }

        private LebenslaufTemplateLoader()
        {
            _Folder = Path.Combine(AppContext.BaseDirectory, typeof(LebenslaufTemplate).Name);
            GeladeneTemplates = [];
            LadeTemplates();

        }

        internal void LadeTemplates()
        {



            if (!Directory.Exists(_Folder))
            {
                Directory.CreateDirectory(_Folder);
                return;
            }

            var files = Directory.GetFiles(_Folder);

            foreach (var file in files)
            {
                var ob = JsonConvert.DeserializeObject<LebenslaufTemplate>(File.ReadAllText(file), new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,


                });

                if (ob != null)
                {
                    if (GeladeneTemplates!.Contains(ob))
                    {
                        int index = GeladeneTemplates.IndexOf(ob);
                        GeladeneTemplates[index] = ob;
                    }
                    else
                    {

                        GeladeneTemplates.Add(ob);
                    }
                }



            }
        }


        public void Löschetemplate(string template)
        {

            GeladeneTemplates = [];
            string debug = template + ".json";
            debug = Path.Combine(_Folder, debug);
            if (File.Exists(Path.Combine(_Folder, template + ".json")))
            {
                File.Delete(debug);

            }

            LadeTemplates();



        }


        private static LebenslaufTemplateLoader _instance;

        public static LebenslaufTemplateLoader Instance => _instance ?? (_instance = new LebenslaufTemplateLoader());


    }
}
