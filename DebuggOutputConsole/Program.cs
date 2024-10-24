using BewerbungsTool.LatexService;
using BewerbungsTool.LatexService.Refactoring;
using BewerbungsTool.Manager;
using BewerbungsTool.ViewModel;
using System.Text;
DebuggTemplateLoader();

void DebuggTemplateLoader()
{
    ExtensionClass.HasValueChanged += ExtensionClass_HasValueChanged;
    DebuggerInit.manager.LeftValueChanged += Manager_LeftValueChanged;
    var tl = DebuggerInit.tl;
    var LvM = DebuggerInit.LvM;
    CVCreatorRefac RefCv = default;

  
    foreach (var item in LvM.LebenslaufTemplate)
    {

        if (item.Name == "CKramer")
        {
            RefCv = new(item, Path.Combine(AppContext.BaseDirectory, "Test"));
           

            break;
        }

    }
}



    


   


void ExtensionClass_HasValueChanged(StringBuilder obj)
{
   
    Console.Write(obj.ToString());
    
}

void Manager_LeftValueChanged(int obj)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{nameof(DebuggerInit.manager.LeftSideValue)}: {obj}");
    Console.ResetColor();
}

public static class DebuggerInit
{

    public static LebenslaufTemplateLoader tl = LebenslaufTemplateLoader.Instance;
    public static LebenslaufViewModel LvM = LebenslaufViewModel.Instance;
    public static CVSeitenverhältnisManager manager = CVSeitenverhältnisManager.Instance;
    

    

}

