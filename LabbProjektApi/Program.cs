using LabbProjektApi.Connections;
using LabbProjektApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.SqlTypes;
using System.Linq;

namespace LabbProjektApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectionHelper.AppConnectors();
        }
    }
}
