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
    public class LoadTemplateManager
    {
        private string _Folder;

        public List<AnschreibenTemplate> GeladeneTemplates { get; private set; }

        private LoadTemplateManager()
        {
            _Folder = Path.Combine(AppContext.BaseDirectory, typeof(AnschreibenTemplate).Name);

            GeladeneTemplates = [];

            LadeTemplates();
        }

        private void LadeTemplates()
        {

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

        private static LoadTemplateManager _instance;

        public static LoadTemplateManager Instance => _instance ?? (_instance = new LoadTemplateManager());




    }
}
