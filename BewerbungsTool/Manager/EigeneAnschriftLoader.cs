using BewerbungsTool.Model;
using Newtonsoft.Json;
using System.IO;

namespace BewerbungsTool.Manager
{
    public class EigeneAnschriftLoader
    {
        private string _Folder;
        public EigeneAnschriftDTO? GeladeneAnschrift { get; set; }

        private EigeneAnschriftLoader() 
        {
            _Folder = Path.Combine(AppContext.BaseDirectory,typeof(EigeneAnschriftDTO).Name);

            LoadDTO();
        }



        private static EigeneAnschriftLoader _instance;

        public static EigeneAnschriftLoader Instance => _instance ?? (_instance = new EigeneAnschriftLoader());




        private void LoadDTO()
        {
            if (!Directory.Exists(_Folder)) 
            {
                Directory.CreateDirectory(_Folder);
                return;
            }
            var file = Directory.GetFiles(_Folder);
            foreach (var f in file) 
            {
                var ob = JsonConvert.DeserializeObject<EigeneAnschriftDTO>(File.ReadAllText(f));
                if (ob != null) 
                {
                    GeladeneAnschrift = ob;
                }

            }
        }
    }
}
