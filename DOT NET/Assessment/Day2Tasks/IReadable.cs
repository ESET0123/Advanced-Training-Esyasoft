using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public interface IReadable
    {
        int ReadKwh();
        string SourceId { get; }
    }

    public class DlmsMeter : IReadable
    {
        public string SourceId { get; }
        private readonly Random _random = new Random();

        public DlmsMeter(string sourceId)
        {
            SourceId = sourceId;
        }

        public int ReadKwh()
        {
            return _random.Next(1, 11);
        }
    }

    public class ModemGateway : IReadable
    {
        public string SourceId { get; }
        private readonly Random _random = new Random();

        public ModemGateway(string sourceId)
        {
            SourceId = sourceId;
        }

        public int ReadKwh()
        {
            return _random.Next(0, 3);
        }
    }

}


