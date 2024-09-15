using BewerbungsTool.Model;
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
    public class TemplateManager
    {
        private string _Folder;

        public List<AnschreibenTemplate> GeladeneTemplates { get; private set; }

        private TemplateManager()
        {
            _Folder = Path.Combine(AppContext.BaseDirectory, typeof(AnschreibenTemplate).Name);

            GeladeneTemplates = [];

            LadeTemplates();
        }

        private void LadeTemplates()
        {


            if (!Directory.Exists(_Folder))
            {
                Directory.CreateDirectory(_Folder);
                return;
            }


            var files = Directory.GetFiles(_Folder);

            foreach (var file in files)
            {
                var ob =   JsonConvert.DeserializeObject<AnschreibenTemplate>(File.ReadAllText(file));
                if (ob != null) 
                {
                    GeladeneTemplates.Add(ob);
                }
            }
          


        }



        public void Löschetemplate(string template)
        {

            GeladeneTemplates = [];
            string debug = template + ".json";
            debug = Path.Combine(_Folder, debug);
            if(File.Exists(Path.Combine(_Folder, template+".json")))
            {
               File.Delete(debug);

            }

            LadeTemplates(); 
               


        }



        private static TemplateManager _instance;

        public static TemplateManager Instance => _instance ?? (_instance = new TemplateManager());




    }
}
