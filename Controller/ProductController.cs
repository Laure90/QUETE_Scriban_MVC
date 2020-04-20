using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.IO;

namespace QUETE_Scriban_MVC
{
    public class ProductController
    {

        public static void WriteProduct(string product)
        {
            TextWriter writeFile = new StreamWriter("test/htmlTest.html");
            writeFile.Write(product);
            writeFile.Flush();
            writeFile.Close();
            writeFile = null;
        }
    }
}
