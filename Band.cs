using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbexample2
{
    public class Band: IDisposable
    {
        public int BandId { get; set; }
        public string BandName { get; set; }

        public void Dispose()
        {
            // nothing to clean up, but if there were, I'd do it here
        }
    }
}
