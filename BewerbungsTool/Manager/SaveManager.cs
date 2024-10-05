using Newtonsoft.Json;
using System.IO;

namespace BewerbungsTool.Manager
{
    public class SaveManager<T> where T : class
    {

        private string _SpeicherOrt;


        T _speicherobject;

        public SaveManager(T speicherObject)
        {

            _SpeicherOrt = Path.Combine(AppContext.BaseDirectory, typeof(T).Name);

            _speicherobject = speicherObject;
            if (!Directory.Exists(_SpeicherOrt))
            {
                Directory.CreateDirectory(_SpeicherOrt);
            }

        }




        public void Save(string name)
        {

            name = name + ".json";
            var filesavepath = Path.Combine(_SpeicherOrt, name);
            string json = JsonConvert.SerializeObject(_speicherobject,Formatting.Indented);

            File.WriteAllText(filesavepath, json);




        }









    }
}
