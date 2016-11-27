using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObject
{
    public class AppInfoDto
    {
        public int ID { get; set; }
        public string AppName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
