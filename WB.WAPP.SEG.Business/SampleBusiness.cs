using System;
using System.Collections.Generic;
using System.Text;

namespace WB.WAPP.SEG.Business
{
    public class SampleBusiness: ISampleBusiness
    {
        public List<string> GetSamples()
        {
            return new List<string>();
        }
    }

    public interface ISampleBusiness
    {
        List<string> GetSamples();
    }
}
