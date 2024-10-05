using BewerbungsTool.Model;
using Newtonsoft.Json;
using System.IO;

namespace BewerbungsTool.Manager
{
    public class AnschreibenTemplateManager
    {
        private string _Folder;

        public List<AnschreibenTemplate> GeladeneTemplates { get; private set; }

        private AnschreibenTemplateManager()
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

        internal void Löschetemplate(string todel)
        {
            throw new NotImplementedException();
        }

        private static AnschreibenTemplateManager _instance;

        public static AnschreibenTemplateManager Instance => _instance ?? (_instance = new AnschreibenTemplateManager());




    }
}
