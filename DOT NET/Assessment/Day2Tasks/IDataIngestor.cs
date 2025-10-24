using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Tasks
{
    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }

    public class DlmsIngestor : IDataIngestor
    {
        public string Name => "Dlms";
        private readonly Random _random = new Random();
        private DateTime _lastReadTime;

        public DlmsIngestor()
        {
            _lastReadTime = DateTime.Today.AddHours(1);
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return (_lastReadTime, _random.Next(1, 6));
                _lastReadTime = _lastReadTime.AddHours(1);
            }
        }
    }

    public class CsvIngestor : IDataIngestor
    {
        public string Name => "Csv";
        private readonly string[] _lines;
        private int _lineIndex = 0;

        public CsvIngestor(string[] lines)
        {
            _lines = lines;
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count && _lineIndex < _lines.Length; i++)
            {
                var parts = _lines[_lineIndex].Split(',');
                yield return (DateTime.Parse(parts[0]), int.Parse(parts[1]));
                _lineIndex++;
            }
        }
    }

    public class RandomOutageDecorator : IDataIngestor
    {
        private readonly IDataIngestor _wrappedIngestor;
        private readonly Random _random = new Random();

        public RandomOutageDecorator(IDataIngestor wrappedIngestor)
        {
            _wrappedIngestor = wrappedIngestor;
        }

        public string Name => $"{_wrappedIngestor.Name}+Outage";

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            foreach (var data in _wrappedIngestor.ReadBatch(count))
            {
                if (_random.Next(0, 5) == 0)
                {
                    yield return (data.ts, 0);
                }
                else
                {
                    yield return data;
                }
            }
        }
    }
}
