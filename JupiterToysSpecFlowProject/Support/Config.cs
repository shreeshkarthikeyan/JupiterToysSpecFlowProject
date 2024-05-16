using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysSpecFlowProject.Support
{
    public class Config
    {
        public string readFromPropertiesFile(string properties)  
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "//Support//project.properties"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

            return data[properties];
        }
    }
}
